using Aplicacion.Abstracciones;
using Infraestructura.Data;

namespace Infraestructura.Repositorios;

public class UnitOfWork : IUnitOfWork
{
    private readonly ContextoECE _contexto;
    private IPacienteRepositorio? _pacienteRepositorio;

    public UnitOfWork(ContextoECE contexto)
    {
        _contexto = contexto;
    }

    public IPacienteRepositorio Pacientes => _pacienteRepositorio ??= new PacienteRepositorio(_contexto);

    public async Task<int> GuardarCambiosAsync()
    {
        return await _contexto.SaveChangesAsync();
    }

    public void Dispose()
    {
        _contexto.Dispose();
    }
}