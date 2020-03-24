namespace CoreEscuela.Entidades
{
    //interface es una definicion de l estructura que debe tener un objeto
    public interface ILugar
    {
        string Dirección { get; set; }

        void LimpiarLugar();
    }
}