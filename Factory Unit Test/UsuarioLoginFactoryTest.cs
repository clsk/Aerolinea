using DataLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Factory_Unit_Test
{
    
    
    /// <summary>
    ///This is a test class for UsuarioLoginFactoryTest and is intended
    ///to contain all UsuarioLoginFactoryTest Unit Tests
    ///</summary>
    [TestClass()]
    public class UsuarioLoginFactoryTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for UsuarioLoginFactory Constructor
        ///</summary>
        [TestMethod()]
        public void UsuarioLoginFactoryConstructorTest()
        {
            Func<string, Usuario> create_delegate = CreateUsuario;
            UsuarioLoginFactory target = new UsuarioLoginFactory(create_delegate);
            target.BuildProduct("aalvarez");
            IUsuario usuario = target.GetProduct();

            //Tests
            Assert.AreEqual<string>(usuario.Nombre, (string)"Alan Alvarez");
            Assert.AreEqual<string>(usuario.Nivel.NombreNivel, (string)"Administrador");
        }

        public static Usuario CreateUsuario(string login)
        {
            Usuario usuario = new Usuario();
            usuario.idUsuario = 5;
            usuario.Nombre = "Alan Alvarez";
            usuario.Login = "aalvarez";
            usuario.Password = "test123";

            usuario.idNivel = 3;
            NivelUsuario nivel = new NivelUsuario();
            nivel.idNivel = 3;
            nivel.NombreNivel = "Administrador";
            nivel.PesoNivel = 500;

            usuario.NivelUsuario = nivel;


            return usuario;
        }
    }
}
