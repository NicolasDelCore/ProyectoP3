using EcosistemasMarinos.LogicaNegocio.Entidades;

namespace EcosistemasMarinos.MVC.Models
{
    public class AsignViewModel
    {
        public IEnumerable<Especie> Especies { get; set; }
        public IEnumerable<Ecosistema> Ecosistemas { get; set; }
    }
}
