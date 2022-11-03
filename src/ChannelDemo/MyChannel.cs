using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace ChannelDemo
{
    public class MyChannel<T>
    {
        private readonly ConcurrentQueue<T> _queue = new ConcurrentQueue<T>();
        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(0);
        private bool _isComplete;

        public void Write(T value)
        {
            _queue.Enqueue(value);
            _semaphore.Release();
        }

        public async ValueTask<T> ReadAsync()
        {
            await _semaphore.WaitAsync();
            return _queue.TryDequeue(out T item) ? item : default;
        }

        public void Complete()
        {
            _isComplete = true;
        }

        public bool IsComplete()
        {
            return _isComplete && _queue.Count == 0;
        }
    }
}