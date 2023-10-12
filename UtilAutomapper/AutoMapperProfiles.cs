using AutoMapper;
using DbConsultoriaModel.dbConsultoria;
using RequestResponse;

namespace UtilAutomapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Cliente, ClienteResponse>().ReverseMap();
            CreateMap<Cliente, ClienteRequest>().ReverseMap();
            CreateMap<ClienteResponse, ClienteRequest>().ReverseMap();

            CreateMap<Consultor, ConsultorResponse>().ReverseMap();
            CreateMap<Consultor, ConsultorRequest>().ReverseMap();
            CreateMap<ConsultorResponse, ConsultorRequest>().ReverseMap();

            CreateMap<Contratistum, ContratistumResponse>().ReverseMap();
            CreateMap<Contratistum, ContratistumRequest>().ReverseMap();
            CreateMap<ContratistumResponse, ContratistumRequest>().ReverseMap();

            CreateMap<Cotizacion, CotizacionResponse>().ReverseMap();
            CreateMap<Cotizacion, CotizacionRequest>().ReverseMap();
            CreateMap<CotizacionResponse, CotizacionRequest>().ReverseMap();

            CreateMap<DetalleCotizacion, DetalleCotizacionResponse>().ReverseMap();
            CreateMap<DetalleCotizacion, DetalleCotizacionRequest>().ReverseMap();
            CreateMap<DetalleCotizacionResponse, DetalleCotizacionRequest>().ReverseMap();

            CreateMap<Empleado, EmpleadoResponse>().ReverseMap();
            CreateMap<Empleado, EmpleadoRequest>().ReverseMap();
            CreateMap<EmpleadoResponse, EmpleadoRequest>().ReverseMap();

            CreateMap<PagoClienteProyecto, PagoClienteProyectoResponse>().ReverseMap();
            CreateMap<PagoClienteProyecto, PagoClienteProyectoRequest>().ReverseMap();
            CreateMap<PagoClienteProyectoResponse, PagoClienteProyectoRequest>().ReverseMap();

            CreateMap<Proyecto, ProyectoResponse>().ReverseMap();
            CreateMap<Proyecto, ProyectoRequest>().ReverseMap();
            CreateMap<ProyectoResponse, ProyectoRequest>().ReverseMap();

            CreateMap<Rol, RolResponse>().ReverseMap();
            CreateMap<Rol, RolRequest>().ReverseMap();
            CreateMap<RolResponse, RolRequest>().ReverseMap();

            CreateMap<Usuario, UsuarioResponse>().ReverseMap();
            CreateMap<Usuario, UsuarioRequest>().ReverseMap();
            CreateMap<UsuarioResponse, UsuarioRequest>().ReverseMap();

            CreateMap<VisitaConsultor, VisitaConsultorResponse>().ReverseMap();
            CreateMap<VisitaConsultor, VisitaConsultorRequest>().ReverseMap();
            CreateMap<VisitaConsultorResponse, VisitaConsultorRequest>().ReverseMap();

            CreateMap<VisitaDetalle, VisitaDetalleResponse>().ReverseMap();
            CreateMap<VisitaDetalle, VisitaDetalleRequest>().ReverseMap();
            CreateMap<VisitaDetalleResponse, VisitaDetalleRequest>().ReverseMap();

            CreateMap<Error, ErrorResponse>().ReverseMap();
            CreateMap<Error, ErrorRequest>().ReverseMap();
            CreateMap<ErrorResponse, ErrorRequest>().ReverseMap();

            CreateMap<Ubigeo, UbigeoResponse>().ReverseMap();
            CreateMap<Ubigeo, UbigeoRequest>().ReverseMap();
            CreateMap<UbigeoResponse, UbigeoRequest>().ReverseMap();
        }
    }
    
}