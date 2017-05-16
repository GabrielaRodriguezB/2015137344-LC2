using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using PaquetesTuristicos.Entities.IRepositories;

namespace CourseStore.Persistence.Repositories
{
    public class UnityOfWork : IUnityOfWork
    {
        
        private static object _Instance;
        private readonly PaquetesTuristicosDbContext _Context;
        private static readonly object _Lock = new object();

        public IAlimentacionRepository Alimentacion { get; private set; }
        public ICalificacionHospedajeRepository CalificacionHospedaje { get; private set; }
        public ICategoriaAlimentacionRepository CategoriaAlimentacion { get; private set; }
        public ICategoriaHospedajeRepository CategoriaHospedaje { get; private set; }
        public ICategoriaTransporteRepository CategoriaTransporte { get; private set; }
        public IClienteRepository Cliente { get; private set; }
        public IComprobantePagoRepository ComprobantePago { get; private set; }
        public IEmpleadoRepository Empleado { get; private set; }
        public IHospedajeRepository Hospedaje { get; private set; }
        public IMedioPagoRepository MedioPago { get; private set; }
        public IPaqueteRepository Paquete { get; private set; }
        public IPersonaRepository Persona { get; private set; }
        public IServicioHospedajeRepository ServicioHospedaje { get; private set; }
        public IServicioTuristicoRepository ServicioTuristico { get; private set; }
        public ITipoComprobanteRepository TipoComprobante { get; private set; }
        public ITipoHospedajeRepository TipoHospedaje { get; private set; }
        public ITipoTransporteRepository TipoTransporte { get; private set; }
        public ITransporteRepository Transporte { get; private set; }
        public IVentaPaqueteRepository VentaPaquete { get; private set; }
        
        private UnityOfWork()
        {
            _Context = new PaquetesTuristicosDbContext();

            Alimentacion = new AlimentacionRepository (_Context);
            CalificacionHospedaje = new CalificacionHospedajeRepository(_Context);
            CategoriaHospedaje = new CategoriaAlimentacionRepository(_Context);
            CategoriaAlimentacion = new CategoriaAlimentacionRepository(_Context);
            CategoriaTransporte = new CategoriaTransporteRepository(_Context);
            Cliente = new ClienteRepository(_Context);
            ComprobantePago = new ComprobantePagoRepository(_Context);
            Empleado = new EmpleadoRepository(_Context);
            Hospedaje = new HospedajeRepository(_Context);
            MedioPago = new MedioPagoRepository(_Context);
            Paquete = new PaqueteRepository(_Context);
            Persona = new PersonaRepository(_Context);
            ServicioHospedaje = new ServicioHospedajeRepository(_Context);
            ServicioTuristico = new ServicioTuristicoRepository(_Context);
            TipoComprobante = new TipoComprobanteRepository(_Context);
            TipoHospedaje = new TipoHospedajeRepository(_Context);
            TipoTransporte = new TipoTransporteRepository(_Context);
            Transporte = new TransporteRepository(_Context);
            VentaPaquete = new VentaPaqueteRepository(_Context);
        }
        public static UnityOfWork Instance
        {
            get
            {
                lock (_Lock)
                {
                    if (_Instance == null)
                        _Instance = new UnityOfWork();
                }

                return _Instance;
            }
        }

        void IDisposable.Dispose()
        {
            _Context.Dispose();
        }

        int IUnityOfWork.SaveChanges()
        {
            return _Context.SaveChanges();
        }
    }
}
