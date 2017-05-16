using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaquetesTuristicos.Entities.IRepositories
{
    public interface IUnityOfWork : IDisposable
    {
        IAlimentacionRepository Alimentacion { get; }
        ICalificacionHospedajeRepository CalificacionHospedaje { get; }
        ICategoriaAlimentacionRepository CategoriaAlimentacion { get;}
        ICategoriaHospedajeRepository CategoriaHospedaje { get; }
        ICategoriaTransporteRepository CategoriaTransporte { get; }
        IClienteRepository Cliente { get; }
        IComprobantePagoRepository ComprobantePago { get; }
        IEmpleadoRepository Empleado { get; }
        IHospedajeRepository Hospedaje { get; }
        IMedioPagoRepository MedioPago { get; }
        IPaqueteRepository Paquete { get; }
        IPersonaRepository Persona { get; }
        IServicioHospedajeRepository ServicioHospedaje { get; }
        IServicioTuristicoRepository ServicioTuristico { get; }
        ITipoComprobanteRepository TipoComprobante { get; }
        ITipoHospedajeRepository TipoHospedaje { get; }
        ITipoTransporteRepository TipoTransporte { get; }
        ITransporteRepository Transporte { get; }
        IVentaPaqueteRepository VentaPaquete { get; }
        int SaveChanges();

    }
}
