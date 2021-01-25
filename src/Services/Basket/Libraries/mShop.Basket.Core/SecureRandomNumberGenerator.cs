using System;
using System.Security.Cryptography;

namespace mShop.Basket.Core
{
    /// <summary>
    /// Represents the class implementation of cryptographic random number generator derive.
    /// </summary>
    public partial class SecureRandomNumberGenerator : RandomNumberGenerator
    {
        /// <summary>
        /// Defines the _disposed.
        /// </summary>
        private bool _disposed = false;

        /// <summary>
        /// Defines the _rng.
        /// </summary>
        private readonly RandomNumberGenerator _rng;

        /// <summary>
        /// Initializes a new instance of the <see cref="SecureRandomNumberGenerator"/> class.
        /// </summary>
        public SecureRandomNumberGenerator()
        {
            _rng = new RNGCryptoServiceProvider();
        }

        /// <summary>
        /// The Next.
        /// </summary>
        /// <returns>The <see cref="int"/>.</returns>
        public int Next()
        {
            var data = new byte[sizeof(int)];
            _rng.GetBytes(data);
            return BitConverter.ToInt32(data, 0) & (int.MaxValue - 1);
        }

        /// <summary>
        /// The Next.
        /// </summary>
        /// <param name="maxValue">The maxValue<see cref="int"/>.</param>
        /// <returns>The <see cref="int"/>.</returns>
        public int Next(int maxValue)
        {
            return Next(0, maxValue);
        }

        /// <summary>
        /// The Next.
        /// </summary>
        /// <param name="minValue">The minValue<see cref="int"/>.</param>
        /// <param name="maxValue">The maxValue<see cref="int"/>.</param>
        /// <returns>The <see cref="int"/>.</returns>
        public int Next(int minValue, int maxValue)
        {
            if (minValue > maxValue)
            {
                throw new ArgumentOutOfRangeException();
            }
            return (int)Math.Floor(minValue + ((double)maxValue - minValue) * NextDouble());
        }

        /// <summary>
        /// The NextDouble.
        /// </summary>
        /// <returns>The <see cref="double"/>.</returns>
        public double NextDouble()
        {
            var data = new byte[sizeof(uint)];
            _rng.GetBytes(data);
            var randUint = BitConverter.ToUInt32(data, 0);
            return randUint / (uint.MaxValue + 1.0);
        }

        /// <summary>
        /// The GetBytes.
        /// </summary>
        /// <param name="data">The data<see cref="byte[]"/>.</param>
        public override void GetBytes(byte[] data)
        {
            _rng.GetBytes(data);
        }

        /// <summary>
        /// The GetNonZeroBytes.
        /// </summary>
        /// <param name="data">The data<see cref="byte[]"/>.</param>
        public override void GetNonZeroBytes(byte[] data)
        {
            _rng.GetNonZeroBytes(data);
        }

        /// <summary>
        /// Dispose secure random.
        /// </summary>
        public new void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        /// <summary>
        /// The Dispose.
        /// </summary>
        /// <param name="disposing">The disposing<see cref="bool"/>.</param>
        protected override void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                _rng?.Dispose();
            }

            _disposed = true;
        }
    }
}
