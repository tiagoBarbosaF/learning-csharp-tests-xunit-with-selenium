using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBank.Infraestrutura.Testes.DTO;

namespace MyBank.Infraestrutura.Testes
{
    public interface IPixRepositorio
    {
       public PixDTO consultaPix(Guid pix);
    }
}
