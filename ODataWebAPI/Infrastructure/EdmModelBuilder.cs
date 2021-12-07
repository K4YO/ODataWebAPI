using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using ODataWebAPI.Models;

namespace ODataWebAPI.Infrastructure
{
    public static class EdmModelBuilder
    {
        private static EdmNavigationProperty _idOcorrenciaProperty;
        public static IEdmModel GetEdmModelV1()
        {
            //_idOcorrenciaProperty = new EdmNavigationProperty();

            var builder = new ODataConventionModelBuilder();
            builder.EntitySet<Pessoa>("Pessoas");
            builder.EntitySet<Ocorrencia>("Ocorrencias");

            //model.
            return builder.GetEdmModel();

        }
    }
}
