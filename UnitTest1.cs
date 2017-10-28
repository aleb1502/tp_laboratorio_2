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
            string dniPrimero = "0";
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
            string dniUltimo = "89.999.999";
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
        /// 
        /// </summary>
        /// <param name="p1"></param>
        [TestMethod]
        public void Valores_Nulos(Profesor p1)
        {
            if (p1.Apellido == null || p1.Nombre == null || p1.DNI == null || p1.Nacionalidad == null)
            {
                throw new SinProfesorException();
            }
        }
    }
}
