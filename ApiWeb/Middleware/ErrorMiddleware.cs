using AutoMapper;
using Bussnies;
using CommonModels;
using IBussnies;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RequestResponse;
using System.Net;

namespace ApiWeb.Middleware
{
    public class ErrorMiddleware
    {
        private readonly RequestDelegate next;
        private readonly IHelperHttpContext _helperHttpContext = null;
        private readonly IMapper _mapper;
        private readonly IErrorBussnies _errorBussnies;

        public ErrorMiddleware(RequestDelegate next, IMapper mapper)
        {
            this.next = next;
            _helperHttpContext = new HelperHttpContext();
            _mapper = mapper;
            _errorBussnies = new ErrorBussnies(mapper);
        }

        public async Task Invoke(HttpContext context)
        {
            /*EN ESTA SECCIÓN - VAMOS A TENER NUESTRA GESTIÓN DE ERRORES
             PARA TODA NUESTRA APLICACIÓN
             */

            try
            {
                /**
                 * ACCIONES QUE SE EJECUTAN ANTES DE PASAR AL CONTROLADOR
                 * PODEMOS REALIZAR ALGUNAS VALIDACIONES DE LOS PARAMETROS QUE 
                 * VIENEN EN EL HEADER
                 */



                context.Request.EnableBuffering();
                await next(context);

            }
            catch (SqlException ex)
            {
                CustomException exx = new CustomException("Error en base de datos", (int)HttpStatusCode.InternalServerError, ex.Number, "Data base", ex);
                await HandleExceptionAsync(context, exx);
            }
            catch (DbUpdateException ex)
            {
                CustomException exx = new CustomException("Error al insertar o actualizar datos en BD", (int)HttpStatusCode.InternalServerError, 500, "Data base", ex);
                await HandleExceptionAsync(context, exx);
            }
            catch (DivideByZeroException ex)
            {
                CustomException exx = new CustomException("Error de divición entre cero", (int)HttpStatusCode.InternalServerError, 500, "Data base", ex);
                await HandleExceptionAsync(context, exx);
            }
            catch (ArithmeticException ex)
            {
                CustomException exx = new CustomException("Error en calculo", (int)HttpStatusCode.InternalServerError, 500, "Data base", ex);
                await HandleExceptionAsync(context, exx);
            }
            catch (CustomException ex)
            {
                await HandleExceptionAsync(context, ex);
            }

        }



        private Task HandleExceptionAsync(HttpContext context, CustomException ex)
        {
            var controllerActionDescriptor = context.GetEndpoint().Metadata.GetMetadata<ControllerActionDescriptor>();
            var controllerName = controllerActionDescriptor.ControllerName;
            var actionName = controllerActionDescriptor.ActionName;

            InfoRequest info = new InfoRequest();
            info = _helperHttpContext.GetInfoRequest(context);
            GenericResponse error = new GenericResponse();

            ErrorRequest err = new ErrorRequest();

            err.Id = 0;
            err.Url = info.RequestHttp.AbsoluteUri;
            err.Controller = info.RequestHttp.Controller;
            err.Ip = info.RequestHttp.Ip;
            err.Method = info.RequestHttp.Method;
            err.UserAgent = info.RequestHttp.UserAgent;
            err.Host = info.RequestHttp.Host;
            err.ClassComponent = "";
            err.FunctionName = "";
            err.LineNumber = 0;
            err.Error1 = ex.Message;
            err.StackTrace = ex.StackTrace != ex.StackTrace ? ex.StackTrace.ToString() : "";
            err.Status = 0;
            err.Request = "";
            err.ErrorCode = 0;
            err.NombreEmpleado = info.Claims.Nombre;
            err.IdUsuarioCrea = info.Claims.UserId;
            //err.IdEmpleado = 1;
            //err.IdUsuarioCrea = 1;
            err.FechaCreacion = DateTime.Now;

            _errorBussnies.Create(err);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = ex.httpCode;
            return context.Response.WriteAsJsonAsync(error);

        }




    }
}
