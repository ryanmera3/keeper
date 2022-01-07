using System;
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
      return _vRepo.Create(newVault);
    }

    public Vault GetById(int id)
    {
      Vault foundVault = _vRepo.GetById(id);
      if (foundVault == null)
      {
        throw new Exception("Invalid vault Id");
      }
      return foundVault;
    }
  }
}