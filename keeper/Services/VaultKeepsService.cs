using System;
using keeper.Models;
using keeper.Repositories;

namespace keeper.Services
{
  public class VaultKeepsService
  {
    private readonly VaultKeepsRepository _vkRepo;

    public VaultKeepsService(VaultKeepsRepository vkRepo)
    {
      _vkRepo = vkRepo;
    }

    public VaultKeep Create(VaultKeep newVaultKeep)
    {
      if(newVaultKeep.CreatorId == null || newVaultKeep.Creator == null)
      {
        throw new Exception("You need to log in");
      }
      
      return _vkRepo.Create(newVaultKeep);
    }
    public VaultKeep GetById(int id)
    {
      VaultKeep foundVaultKeep = _vkRepo.GetById(id);
      if (foundVaultKeep == null)
      {
        throw new Exception("Unable to find vaultKeep with that Id");
      }
      return foundVaultKeep;
    }

    internal void Delete(int id, string userId)
    {
      VaultKeep verifyDelete = GetById(id);
      if (verifyDelete.CreatorId != userId)
      {
        throw new Exception("You cannot delete this");
      }
      _vkRepo.Delete(id);
    }
  }
}