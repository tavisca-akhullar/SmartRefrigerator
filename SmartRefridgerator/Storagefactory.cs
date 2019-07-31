using System;

namespace SmartRefridgerator
{
        public class StorageFactory
        {
            public IStorage GetStorage(String type)
            {
                switch (type)
                {
                    case "inmemory":
                        return new InMemoryStorage();
                    default:
                        throw new NotSupportedException();
                }
            }
        }
    }
    
