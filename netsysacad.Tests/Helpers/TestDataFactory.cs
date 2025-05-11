using netsysacad.Models;
namespace netsysacad.Tests.Helpers;

    public static class TestDataFactory
    {
        public static CategoriaCargo CreateCategoriaCargo() => new()
        {
            Nombre = "Administrativo"
        };
        public static TipoDedicacion CreateTipoDedicacion() => new()
        {
            Nombre = "Exclusiva",
            Observacion = "Dedicación exclusiva a la docencia e investigación"
        };
        public static Cargo CreateCargo() => new()
        {
            Nombre = "Profesor Titular",
            Puntos = 100,
            CategoriaCargo = CreateCategoriaCargo(),
            TipoDedicacion = CreateTipoDedicacion(),
        };
        public static TipoEspecialidad CreateTipoEspecialidad() => new()
        {
                Nombre = "Técnica",
                Nivel = "Intermedio"
        };
        public static Especialidad CreateEspecialidad() => new()
        {
            Nombre = "Ingeniería de Software",
            Letra = "S",
            Observacion = "Orientada al desarrollo de sistemas",
            TipoEspecialidad = CreateTipoEspecialidad()
        };
        public static Autoridad CreateAutoridad() => new()
        {
            Nombre = "PruebaAutoridad", 
            Cargo = "rrhh",
            Telefono = "1234553",
            Email = "hguthg@gmail.com"
        };
        public static Universidad CreateUniversidad() => new()
        {
            Nombre = "UTN", 
            Sigla = "FRSR"
        };
        public static Facultad CreateFacultad() => new()
        {
            Nombre = "Facultad de Sistemas", 
            Abreviatura = "Sist.",
            Directorio = "Computación",
            Sigla = "FS",
            CodigoPostal = "5600",
            Ciudad = "San Rafael",
            Domicilio = "Av Rivadavia 1234",
            Telefono = "123456789",
            Contacto = "Pepito Juan",
            Email = "utn@gmail.com",
            Universidad = CreateUniversidad(),
            Autoridades = [CreateAutoridad()]
        };
        public static Materia CreateMateria() => new()
        {
            Nombre = "Desarrollo de software",
            Codigo = "102",
            Observacion = "Ninguna observacion"
        };
        public static Plan CreatePlan() => new()
        {
            Nombre = "Plan 2020",
            FechaInicio = "2020-03-01",
            FechaFin = "2025-12-31",
            Observacion = "Plan de estudios vigente"
        };
        public static Orientacion CreateOrientacion() => new()
        {
           Nombre = "Ciencia de Datos",
           Especialidad = CreateEspecialidad(),
           Plan = CreatePlan(),
           Materias = [CreateMateria()]
        };
    }

//using netsysacad.Tests.Helpers; TestDataFactory.