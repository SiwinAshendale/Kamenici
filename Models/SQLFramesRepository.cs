using Kamenici.Data;

namespace Kamenici.Models
{
    public class SQLFramesRepository: IFramesRepository
    {
        private readonly ApplicationDbContext context;
        public SQLFramesRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public Frame Add(Frame frame)
        {
            context.Frames.Add(frame);
            context.SaveChanges();
            return frame;
        }

        public Frame Delete(int id)
        {
            Frame frame = context.Frames.Find(id);
            if(frame != null)
            {
                context.Frames.Remove(frame);
                context.SaveChanges();
            }
            return frame;
        }

        public IEnumerable<Frame> getAllFrames()
        {
            return context.Frames;
        }

        public Frame getFrame(int id)
        {
            return context.Frames.Find(id);
        }

        public Frame Update(Frame frameChanges)
        {
            var frame = context.Frames.Attach(frameChanges);
            frame.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return frameChanges;
        }
    }
}
