using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones;
using EntidadesAbstractas;
using Clases_Instanciables;


namespace TestUnitario1
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Comprobar que el DNI en formato texto no pueda tener:
        /// Coma
        /// Letras
        /// Arroja DniInvalidoException
        /// </summary>
        [TestMethod]
        public void DNI_Invalido_Texto()
        {
            // CASO 1 DNI con COMA
            string dniComa = "30.999,999";
            try
            {
                // DNI Invalido?
                Alumno personaPrimero = new Alumno(12,"Juan", "Lopez", dniComa, Persona.ENacionalidad.Argentino,Universidad.EClases.SPD);
                Assert.Fail("Sin excepción para DNI inválido: {0}.", dniComa);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(DniInvalidoException));
            }

            // CASO 2 DNI con texto
            string dniTexto = "30a00123";
            try
            {
                // DNI Invalido?
                Alumno personaUltimo = new Alumno(12,"Juan", "Lopez", dniTexto, Persona.ENacionalidad.Argentino,Universidad.EClases.SPD);
                Assert.Fail("Sin excepción para DNI inválido: {0}.", dniTexto);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(DniInvalidoException));
            }
        }

        /// <summary>
        /// Comprobar que el DNI no pueda ser menor a 1
        /// Arroja NacionalidadInvalidaException
        /// </summary>
        [TestMethod]
        public void DNI_Invalido_Bajo()
        {
            // CASO 1 DNI menor a 1
            string dniPrimero = "98000000";
            try
            {
                // DNI Invalido?
                Alumno personaPrimero = new Alumno(12,"Juan", "Lopez", dniPrimero, Persona.ENacionalidad.Argentino,Universidad.EClases.SPD);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(NacionalidadInvalidaException));
                return;
            }
            Assert.Fail("Sin excepción para DNI inválido: {0}.", dniPrimero);
        }

        /// <summary>
        /// Comprobar que el DNI no pueda ser mayor a 99.999.999
        /// </summary>
        [TestMethod]
        public void DNI_Invalido_Alto()
        {
            // CASO 2 DNI mayor a 89.999.999
            string dniUltimo = "89999999";
            try
            {
                // DNI Invalido?
                Alumno personaUltimo = new Alumno(12,"Juan", "Lopez", dniUltimo, Persona.ENacionalidad.Extranjero,Universidad.EClases.SPD);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(NacionalidadInvalidaException));
                return;
            }
            Assert.Fail("Sin excepción para DNI inválido: {0}.", dniUltimo);
        }

        /// <summary>
        /// Valida que la nacionalidad sea valida
        /// </summary>
        [TestMethod]
        public void Nacionalidad_Invalida()
        {
            //CASO 3: Nacionalidad invalida
            Persona.ENacionalidad n1 = Persona.ENacionalidad.Argentino;
            Alumno personaUltimo = new Alumno(20, "Edith", "Garcia", "35789654", n1, Universidad.EClases.SPD);

            Assert.AreEqual(personaUltimo.Nacionalidad,n1);
        }

        /// <summary>
        /// Valida que la nacionalidad sea valida
        /// </summary>
        [TestMethod]
        public void Nacionalidad_Invalida2()
        {
            //CASO 3: Nacionalidad invalida
            try
            {
                Alumno personaExt = new Alumno(20, "Edith", "Garcia", "35789654", Persona.ENacionalidad.Extranjero, Universidad.EClases.SPD);
                Assert.Fail("Sin excepcion para nacionalidad extranjera");
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e,typeof(NacionalidadInvalidaException));
            }

            try
            {
                Alumno personaArg = new Alumno(21, "Joaquin", "Bermudez", "95789654", Persona.ENacionalidad.Argentino, Universidad.EClases.SPD);
                Assert.Fail("Sin excepcion para nacionalidad argentina");
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e,typeof(NacionalidadInvalidaException));
            }
        }

        /// <summary>
        /// Comprobar los rangos de DNI para Argentinos
        /// </summary>
        [TestMethod]
        public void DNI_Validos_Argentino()
        {
            string dniString = "89999999";
            Alumno personaString = new Alumno(12,"Juan", "Lopez", dniString, Persona.ENacionalidad.Argentino,Universidad.EClases.SPD);
            // Cargó OK?
            Assert.AreEqual(personaString.DNI, 89999999);
        }

        /// <summary>
        /// Valida que no haya valores nulos en algun atributo de la clase
        /// </summary>
        /// <param name="p1"></param>
        [TestMethod]
        public void Valores_Nulos(Profesor p1)
        {
            if (p1.Apellido == null || p1.Nombre == null || p1.DNI == 0 || p1.Nacionalidad == 0)
            {
                throw new SinProfesorException();
            }
        }
    }
}
