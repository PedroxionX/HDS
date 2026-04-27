namespace Aplicacion.Abstracciones;

public interface IUnitOfWork : IDisposable
{
    IPacienteRepositorio Pacientes { get; }
    Task<int> GuardarCambiosAsync();
}