using System;
using keeper.Models;
using keeper.Repositories;

namespace keeper.Services
{
  public class VaultKeepsService
  {
    private readonly VaultKeepsRepository _vkRepo;
    private readonly VaultsService _vs;

    public VaultKeepsService(VaultKeepsRepository vkRepo, VaultsService vs)
    {
      _vkRepo = vkRepo;
      _vs = vs;
    }

    public VaultKeep Create(VaultKeep newVaultKeep)
    {
      Vault vault = _vs.GetById(newVaultKeep.VaultId, newVaultKeep.CreatorId);
      if(newVaultKeep.CreatorId == null || newVaultKeep == null )
      {
        throw new Exception("You need to log in");
      }
      if(vault.CreatorId != newVaultKeep.CreatorId)
      {
        throw new Exception("You cannot create a keep in another's vault");
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