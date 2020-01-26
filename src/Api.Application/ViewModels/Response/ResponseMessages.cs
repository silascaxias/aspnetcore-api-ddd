using System.Collections.Generic;

namespace Api.Application.ViewModels.Response
{
    public class ResponseMessages
    {
        public static IDictionary<ResponseStatusEnum, string> Messages = new Dictionary<ResponseStatusEnum, string>()
        {
            { ResponseStatusEnum.Error, "Erro interno de servidor" },
            { ResponseStatusEnum.Success, "Sucesso" },
            { ResponseStatusEnum.NoModified, "Não foi possivel modificar" },
            { ResponseStatusEnum.NotFound, "Não encontrado" },
            { ResponseStatusEnum.BadRequest, "Verifique os campos informados" },
            { ResponseStatusEnum.Unprocessable, "Parâmetros inválidos" },
            { ResponseStatusEnum.Forbidden, "Usuário não tem permissão" },
            { ResponseStatusEnum.Conflict, "Conflito" },
            { ResponseStatusEnum.Unauthorized, "Acesso não autorizado" }
        };
    }
}