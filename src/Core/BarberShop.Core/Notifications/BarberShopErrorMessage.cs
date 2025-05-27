namespace BarberShop.Core.Notifications
{
    public static class BarberShopErrorMessage
    {
        #region User
        public static string ERROR_NAME_REQUIRED = "O campo nome precisa ser informado";
        public static string ERROR_NAME_LENGTH = "O campo nome precisa ter entre {MinLength} e {MaxLength} caracteres";
        public static string ERROR_USER_ID = "Usuário deve ser informado!";
        #endregion

        #region Haircut
        public static string ERROR_VALUE_PRICE = "O valor do corte deve ser informado!";
        public static string ERROR_HAIRCUT_EXISTS = "Corte de Cabelo Já cadastrado.";
        public static string ERROR_HAIRCUT_NOT_FOUND = "Corte de Cabelo não encontrado";
        public static string ERROR_HAIRCUT_LIMIT = "Nao autorizado";
        #endregion
    }
}
