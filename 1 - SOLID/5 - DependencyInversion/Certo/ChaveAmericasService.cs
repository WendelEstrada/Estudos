using DependencyInversion.Certo.Interfaces;

namespace DependencyInversion.Certo
{
    public class ChaveAmericasService : IChaveAmericasService
    {
        public bool EhValida(string chaveAmericas)
        {
            return PossuiConteudo(chaveAmericas) && TamanhoValido(chaveAmericas);
        }

        private static bool TamanhoValido(string chaveAmericas)
        {
            return chaveAmericas.Length <= 10;
        }

        private static bool PossuiConteudo(string chaveAmericas)
        {
            return string.IsNullOrWhiteSpace(chaveAmericas);
        }
    }
}