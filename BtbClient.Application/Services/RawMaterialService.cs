using BtbClient.Application.Interfaces.IServices;
using BtbClient.Application.Interfaces.IUnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace BtbClient.Application.Services
{
    public class RawMaterialService 
    {
        private readonly IUnitOfWork _unitOfWork;

        public RawMaterialService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

    }
}
