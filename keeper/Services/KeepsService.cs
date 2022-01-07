using System;
using System.Collections.Generic;
using keeper.Models;
using keeper.Repositories;

namespace keeper.Services
{
  public class KeepsService
  {
    private readonly KeepsRepository _kRepo;

    public KeepsService(KeepsRepository kRepo)
    {
      _kRepo = kRepo;
    }

    internal Keep Create(Keep newKeep)
    {
      return _kRepo.Create(newKeep);
    }

    public List<Keep> GetAll()
    {
      return _kRepo.GetAll();
    }

    public Keep GetById(int id)
    {
      Keep foundKeep = _kRepo.GetById(id);
      if (foundKeep == null)
      {
        throw new Exception("Unable to find keep with that Id");
      }
      return foundKeep;
    }

    internal Keep Edit(Keep update)
    {
      Keep original = GetById(update.Id);
      if (original.CreatorId != update.CreatorId)
      {
        throw new Exception("You cannot edit this");
      }
      original.Description = update.Description != null && update.Description.Trim().Length > 0 ? update.Description : original.Description;
      original.Name = update.Name != null && update.Name.Trim().Length > 0 ? update.Name : original.Name;
      original.Img = update.Img != null && update.Img.Trim().Length > 0 ? update.Img : original.Img;
      _kRepo.Edit(original);
      return original;
    }

    internal void Delete(int id, string userId)
    {
      Keep verifyDelete = GetById(id);
      if (verifyDelete.CreatorId != userId)
      {
        throw new Exception("You cannot delete this");
      }
      _kRepo.Delete(id);
    }
  }
}