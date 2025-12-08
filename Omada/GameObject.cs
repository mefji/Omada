namespace Omada
{
    public abstract class GameObject
    {
        public bool IsActive { get; set; } = true;

        public virtual void Update(float deltaTime)
        {

        }

        public virtual void Render(char[] buffer)
        {

        }
    }
}
