using System;
using System.Collections.Generic;
using keeper.Models;
using keeper.Repositories;

namespace keeper.Services
{
  public class VaultsService
  {
    private readonly VaultsRepository _vRepo;

    public VaultsService(VaultsRepository vRepo)
    {
      _vRepo = vRepo;
    }

    internal Vault Create(Vault newVault)
    {
      if (newVault.CreatorId == null)
      {
        throw new Exception("You aren't logged in");
      }
      return _vRepo.Create(newVault);
    }

    public Vault GetById(int id, string userId)
    {
      Vault foundVault = _vRepo.GetById(id);
      if (foundVault == null)
      {
        throw new Exception("Invalid vault Id");
      }
      if (foundVault.IsPrivate == true && foundVault.CreatorId != userId)
      {
        throw new Exception("You cannot view this Vault");
      }
      return foundVault;
    }
    public Vault GetByVaultId(int id)
    {
      Vault foundVault = _vRepo.GetById(id);
      if (foundVault == null)
      {
        throw new Exception("Unable to find that vault");
      }
      
      return foundVault;
    }

    internal List<Vault> GetByCreatorId(string id)
    {
      List<Vault> foundVaults =  _vRepo.GetByCreatorId(id);
      foundVaults = foundVaults.FindAll(v => v.IsPrivate == false);
      return foundVaults;
    }

    internal Vault Edit(Vault update)
    {
      Vault original = GetById(update.Id, update.CreatorId);
      if (update.CreatorId != original.CreatorId)
      {
        throw new Exception("You cannot edit this");
      }
      original.Name = update.Name != null && update.Name.Trim().Length > 0 ? update.Name : original.Name;
      original.Description = update.Description != null && update.Description.Trim().Length > 0 ? update.Description : original.Description;
      original.IsPrivate = update.IsPrivate != original.IsPrivate ? update.IsPrivate : original.IsPrivate;
      _vRepo.Edit(original);
      return original;
    }

    public List<Vault> GetMyVaults(string id)
    {
      return _vRepo.GetMyVaults(id);
    }

    internal void Delete(int id, string userId)
    {
      Vault toDelete = GetById(id, userId);
      if (toDelete.CreatorId != userId)
      {
        throw new Exception("You cannot delete this");
      }
      _vRepo.Delete(id);
    }
  }
}