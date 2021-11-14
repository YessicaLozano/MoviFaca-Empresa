using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviFaca_Empresa.Vista.Menu
{
    public class MenuEmpresaFlyoutMenuItem
    {
        public MenuEmpresaFlyoutMenuItem()
        {
            TargetType = typeof(MenuEmpresaFlyoutMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
        public string Icono { get; set; }
    }
}