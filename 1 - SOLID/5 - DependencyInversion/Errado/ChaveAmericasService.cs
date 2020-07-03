namespace DependencyInversion.Errado
{
    public static class ChaveAmericasService
    {
        public static bool EhValida(string chaveAmericas)
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