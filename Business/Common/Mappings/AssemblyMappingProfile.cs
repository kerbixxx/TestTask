using System.Reflection;
using AutoMapper;

namespace Business.Common.Mappings
{
    public class AssemblyMappingProfile : Profile
    {
        public AssemblyMappingProfile(Assembly assembly) => ApplyMappingsFromAssembly(assembly);

        //Ищем все типы, которые реализуют определенный интерфейс IMapWith
        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            var types = assembly.GetExportedTypes()
                .Where(type=>type.GetInterfaces()
                    .Any(i=>i.IsGenericType && 
                    i.GetGenericTypeDefinition()==typeof(IMapWith<>))) 
                .ToList();

            //Для каждого типа создается экземпляр и вызывается метод Mapping
            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);
                var methodInfo = type.GetMethod("Mapping");
                methodInfo?.Invoke(instance, new object[] { this });
            }
        }
    }
    //Этот код позволяет автоматически настраивать маппинги между типами, определенными в указаной сборке
    //Без необходимости явного указания каждого маппинга вручную.
}
