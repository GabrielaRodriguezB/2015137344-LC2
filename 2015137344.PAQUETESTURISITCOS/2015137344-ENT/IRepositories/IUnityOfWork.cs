using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2015137344_ENT.Entities;

namespace _2015137344_ENT.IRepositories
{
    public interface IUnityOfWork : IDisposable
    {
        IAlimentacionRepository Alimentaciones { get; }
        ICalificacionHospedajeRepository CalificacionesHospedaje { get; }
        ICategoriaAlimentacionRepository CategoriasAlimentacion { get; }
        ICategoriaHospedajeRepository CategoriasHospedaje { get; }
        ICategoriaTransporteRepository CategoriasTransporte { get; }
        IClienteRepository Clientes { get; }
        IComprobantePagoRepository ComprobantesPago { get; }
        IEmpleadoRepository Empleados { get; }
        IHospedajeRepository Hospedajes { get; }
        IMedioPagoRepository MediosPago { get; }
        IPaqueteRepository Paquetes { get; }
        IPersonaRepository Personas { get; }
        IServicioHospedajeRepository ServiciosHospedaje { get; }
        IServicioTuristicoRepository ServiciosTuristicos { get; }
        ITipoComprobanteRepository TiposComprobante { get; }
        ITipoHospedajeRepository TiposHospedaje { get; }
        ITipoTransporteRepository TiposTransporte { get; }
        ITransporteRepository Transportes { get; }
        IVentaPaqueteRepository VentasPaquetes { get; }

        
        int SaveChanges();

        void StateModified(object entity);
    }
}