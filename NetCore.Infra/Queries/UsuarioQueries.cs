using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Infra.Repositories
{
    public partial class UsuarioRepository
    {
        #region SELECT
        private const string LISTAR_USUARIOS =
                            @"SELECT *
                                FROM [dbo].[Users]";

        private const string BUSCAR_USUARIO =
                            @"SELECT *
                              FROM [dbo].[Users]
                              WHERE Email = @Email";

        private const string BUSCAR_USUARIO_ID =
                            @"SELECT *
                                FROM [dbo].[Users]
                                WHERE [Id] = @Id";
        #endregion

        #region UPDATE
        private const string ATUALIZAR_USUARIO =
                            @"UPDATE [dbo].[Users]
                                       SET [UserName] = @UserName
                                          ,[PasswordHash] = @PasswordHash
                                          ,[PasswordSalt] = @PasswordSalt
                                          ,[Email] = @Email
                                          ,[EmailConfirmed] = @EmailConfirmed
                                          ,[IsEnabled] = @IsEnabled
                                WHERE Id = @Id ";
        #endregion

        #region INSERT
        private const string SALVAR_USUARIO =
                           @"INSERT INTO [dbo].[Users]
                                               ([Id]
                                               ,[UserName]
                                               ,[PasswordHash]
                                               ,[PasswordSalt]
                                               ,[Email]
                                               ,[EmailConfirmed]
                                               ,[IsEnabled])
                                         VALUES
                                               (@Id
                                               ,@UserName
                                               ,@PasswordHash
                                               ,@PasswordSalt
                                               ,@Email
                                               ,@EmailConfirmed
                                               ,@IsEnabled)";
        #endregion
    }
}
