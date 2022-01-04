using Kamenici.Data;
namespace Kamenici.Models
{
    public interface IFramesRepository
    {
        Frame getFrame(int id);
        IEnumerable<Frame> getAllFrames();
        Frame Add(Frame frame);
        Frame Update(Frame frame);
        Frame Delete(int id);
    }
}
