﻿namespace ArchiNote.SharedKernel;

public abstract class Entity
{
    public Guid Id { get; set; }
    public DateTime Created { get; set; }
    public DateTime Modified { get; set; }
}