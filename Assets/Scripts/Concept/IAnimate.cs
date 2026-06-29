namespace DefaultNamespace.Concept
{
    public interface IAnimate
    {
        bool IsAnimating { get; set; }
        
        void Animate(bool stopExistingTween);
        void Pause();
        void Resume();
        void Stop();
    }
}