using _2015137344_ENT.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2015137344_ENT.Entities;

namespace _2015137344_PER.Repositories
{
    public class UnityOfWork : IUnityOfWork
    {
        private readonly PaquetesTuristicosDbContext _Context;
        private static UnityOfWork _Instance;
        private static readonly object _Lock = new object();

        public IAlimentacionRepository Alimentaciones { get; private set; }
        public ICalificacionHospedajeRepository CalificacionesHospedaje { get; private set; }
        public ICategoriaAlimentacionRepository CategoriasAlimentacion { get; private set; }
        public ICategoriaHospedajeRepository CategoriasHospedaje { get; private set; }
        public ICategoriaTransporteRepository CategoriasTransporte { get; private set; }
        public IClienteRepository Clientes { get; private set; }
        public IComprobantePagoRepository ComprobantesPago { get; private set; }
        public IEmpleadoRepository Empleados { get; private set; }
        public IHospedajeRepository Hospedajes { get; private set; }
        public IMedioPagoRepository MediosPago { get; private set; }
        public IPaqueteRepository Paquetes { get; private set; }
        public IPersonaRepository Personas { get; private set; }
        public IServicioHospedajeRepository ServiciosHospedaje { get; private set; }
        public IServicioTuristicoRepository ServiciosTuristicos { get; private set; }
        public ITipoComprobanteRepository TiposComprobante { get; private set; }
        public ITipoHospedajeRepository TiposHospedaje { get; private set; }
        public ITipoTransporteRepository TiposTransporte { get; private set; }
        public ITransporteRepository Transportes { get; private set; }
        public IVentaPaqueteRepository VentasPaquetes { get; private set; }

        private UnityOfWork(PaquetesTuristicosDbContext context)
        {
            _Context = new PaquetesTuristicosDbContext();

            Alimentaciones = new AlimentacionRepository(_Context);
            CalificacionesHospedaje = new CalificacionHospedajeRepository(_Context);
            CategoriasAlimentacion = new CategoriaAlimentacionRepository(_Context);
            CategoriasHospedaje = new CategoriaHospedajeRepository(_Context);
            CategoriasTransporte = new CategoriaTransporteRepository(_Context);
            Clientes = new ClienteRepository(_Context);
            ComprobantesPago = new ComprobantePagoRepository(_Context);
            Empleados = new EmpleadoRepository(_Context);
            Hospedajes = new HospedajeRepository(_Context);
            MediosPago = new MedioPagoRepository(_Context);
            Paquetes = new PaqueteRepository(_Context);
            Personas = new PersonaRepository(_Context);
            ServiciosHospedaje = new ServicioHospedajeRepository(_Context);
            ServiciosTuristicos = new ServicioTuristicoRepository(_Context);
            TiposComprobante = new TipoComprobanteRepository(_Context);
            TiposHospedaje = new TipoHospedajeRepository(_Context);
            TiposTransporte = new TipoTransporteRepository(_Context);
            Transportes = new TransporteRepository(_Context);
            VentasPaquetes = new VentaPaqueteRepository(_Context);
        }

        public UnityOfWork()
        {

        }

        
          

        public void Dispose()
        {
            _Context.Dispose();
        }

        //metodo que guarda los cambios. lleva los cambios en memoria hacia la base de datos.
        public int SaveChanges()
        {
            return _Context.SaveChanges();
        }

        //metodo que cambia el estado de una entidad en el entityframework para que luego se cambie en la base de datos
        public void StateModified(object Entity)
        {
            _Context.Entry(Entity).State = System.Data.Entity.EntityState.Modified;
        }

        
    }
}