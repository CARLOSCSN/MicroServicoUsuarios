using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetCore.Api.Controllers;
using NetCore.AppServices.AutoMapper;
using NetCore.AppServices.Commands.Usuario;
using NetCore.AppServices.Services;
using NetCore.CrossCutting;
using NetCore.Domain.Services;
using NetCore.Infra.Repositories;
using System.Threading.Tasks;

namespace NetCore.Tests
{
    [TestClass]
    public class NetCoreTest : BaseTest
    {
        public UsuarioController _controller { get; set; }
        public UsuarioAppService _appService { get; set; }
        public UsuarioService _service { get; set; }
        public JwtService _jswtService { get; set; }
        public UsuarioRepository _repository { get; set; }


        [TestMethod]
        public async Task RegistrarUsuarioTest()
        {
            ConnectionStrings.BancoDadosConnection = bancoDadosConnection;

            _repository = new UsuarioRepository();
            _service = new UsuarioService(_repository);
            _appService = new UsuarioAppService(AutoMapperConfiguration.RegisterMappings().CreateMapper(), _service, _jswtService);
            _controller = new UsuarioController(_appService);

            var pessoa = new UsuarioPessoaCommand()
            {
                Nome = "Carlos Santana Nunes",
                Email = "carlos.santana.max@gmail.com",
                Senha = "santana100",
                ConfirmacaoSenha = "santana100"
            };

            var result = await _controller.RegistrarUsuario(pessoa);

            Assert.IsNotNull(result);
            Assert.IsTrue(true);
        }

        [TestMethod]
        public async Task LoginTest()
        {
            ConnectionStrings.BancoDadosConnection = bancoDadosConnection;

            _repository = new UsuarioRepository();
            _service = new UsuarioService(_repository);
            _appService = new UsuarioAppService(AutoMapperConfiguration.RegisterMappings().CreateMapper(), _service, _jswtService);
            _controller = new UsuarioController(_appService);

            var credencial = new CredencialCommand()
            {
                Email = "carlos.santana.max@gmail.com",
                Senha = "santana100"
            };

            var result = await _controller.Login(credencial);

            Assert.IsNotNull(result);
            Assert.IsTrue(true);
        }

    }
}
