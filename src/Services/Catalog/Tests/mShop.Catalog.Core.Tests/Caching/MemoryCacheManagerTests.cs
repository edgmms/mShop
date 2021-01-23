using FluentAssertions;
using Microsoft.Extensions.Caching.Memory;
using mShop.Catalog.Core.Caching;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace mShop.Catalog.Core.Tests.Caching
{
    [TestFixture]
    public class MemoryCacheManagerTests
    {
        private MemoryCacheManager _cacheManager;

        [SetUp]
        public void Setup()
        {
            _cacheManager = new MemoryCacheManager(new MemoryCache(new MemoryCacheOptions()));
        }

        [Test]
        public void Can_set_and_get_object_from_cache()
        {
            _cacheManager.Set("some_key_1", 3);
            _cacheManager.Get("some_key_1", () => 0).Should().Be(3);
        }

        [Test]
        public void Can_set_and_get_object_from_cache_async()
        {
            _cacheManager.Set("some_key_1", 3);
            _cacheManager.GetAsync("some_key_1", () =>
            {
                return Task.Delay(10000).ContinueWith(t => 3);

            }).Result.Should().Be(3);
        }

        [Test]
        public void Can_validate_whetherobject_is_cached()
        {
            _cacheManager.Set("some_key_1", 3);
            _cacheManager.Set("some_key_2", 4);

            _cacheManager.IsSet("some_key_1").Should().BeTrue();
            _cacheManager.IsSet("some_key_3").Should().BeFalse();
        }

        [Test]
        public void Can_clear_cache()
        {
            _cacheManager.Set("some_key_1", 3);

            _cacheManager.Clear();

            _cacheManager.IsSet("some_key_1").Should().BeFalse();
        }

        [Test]
        public void Can_remove_by_key()
        {
            _cacheManager.Set("some_key_1", 1);
            _cacheManager.IsSet("some_key_1").Should().BeTrue();
            _cacheManager.Remove("some_key_1");
            _cacheManager.IsSet("some_key_1").Should().BeFalse();
        }
    }
}
