using System;
using System.CodeDom;

namespace cmdGame

{
    public class Game:ILifeCycle
    {
        public World world;
        public EGameState state;
        public void Awake() {
            Debug.Log($"{GetType().Name} Awake");
            world = new World();
            world.Awake();
            //TODO create actors
            world.AddActor(CreatePlayer(1000,40));
            world.AddActor(CreateEnemy(300,10));
            world.AddActor(CreateEnemy(300,10));
            world.AddActor(CreateEnemy(300,10));

        }
        Actor CreatePlayer(int health,int damage)
        {
            var player = new Player();
            InitActor(player, health, damage);
            player.AddComponent(new PlayerAI());
            return player;
        }

        Actor CreateEnemy(int health, int damage)
        {

            var enemy = new Enemy();//为什么一个enemy可以有多个同名实例？
            InitActor(enemy,health, damage);
            enemy.AddComponent(new EnemyAI());
            return enemy;
        }

        private void InitActor(Actor actor,int health, int damage)
        {
            actor.world = world;
            actor.damage = health;
            actor.health = damage;
            actor.pos=world.GetRandomPos();
            actor.AddComponent(new HurtEffect());
            actor.AddComponent(new Skill());
        }
        

        public void Update() 
        {
            Debug.Log($"{GetType().Name} Update FrameCount{Time.FrameCount}");
            world.Update();
            Time.FrameCount++;
        }


        public bool OnUpdate(double timeSinceStart,double deltaTime)
        {
            Time.deltaTime=(float)deltaTime;
            Update();
            return false;
        }
        public void OnGetInput(char inputCh)
        {
            switch (inputCh)
            {
                case 'w':InputManager.inputVec = new Vector2(0, 1);break;
                case 's':InputManager.inputVec = new Vector2(0, -1);break;
                case 'a':InputManager.inputVec = new Vector2(-1, 0);break;
                case 'd':InputManager.inputVec = new Vector2(1, 0);break;
            }
        }
    }

        
    
}
