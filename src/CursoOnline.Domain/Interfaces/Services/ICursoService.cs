﻿
using CursoOnline.Domain.Entities;

namespace CursoOnline.Domain.Interfaces.Services;

public interface ICursoService : IBaseService<Curso>
{
    Task<IEnumerable<Curso>> GetByName(string name);
}
