using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public enum EnemyState//状态枚举
{
Patrol,//巡逻
Attack,//攻击
Rest,//休息
Chase//追击
}
public class FsmDemo : MonoBehaviour {

    public EnemyState enemyState;
    private Transform Player;//主角

    public float EnemyRestTime = 3;//控制休息时间
    private float RestTime;//休息时间

    private Animator EnemyAnimator;//动画控制器

    public float MaxSightDistance = 10;//最大的视野范围
    public float CanAttackDistance = 1;//攻击范围

    public Transform MoveTarget;//最终要移动到的目标
    public Transform point;//路点父物体
    public List<Transform> Points = new List<Transform>();//路点的链表数组

    private NavMeshAgent m_navmeshment;//寻路组件

    private int index = 0;//路点索引
    public bool canmove = true;//是否可以移动
    void Start() {
        m_navmeshment = GetComponent<NavMeshAgent>();//获取寻路组件
        RestTime = EnemyRestTime;//初始化休息时间
        EnemyAnimator = GetComponent<Animator>();//获取动画控制器
        Player = GameObject.FindWithTag("Player").transform;//获取主角
        enemyState = EnemyState.Rest;//初始化状态

        for (int i = 0; i < point.childCount; i++)//获取父物体下面的路点
        {
            Points.Add(point.GetChild(i));
        }
        MoveTarget = Points[0];//初始化移动目标
        if (m_navmeshment == null || Player == null || EnemyAnimator == null)//以防出错
        {
            Debug.LogError("未添加完整组件或者是标签");
            enabled = false;
            return;
        }
      
	}
	
	// Update is called once per frame
	void Update () {

        DealWithEnemyState();
        //Debug.DrawLine(transform.position, transform.forward, Color.red);
        //Debug.DrawLine(transform.position, Player.position - transform.position, Color.red);
	}
    private void DealWithEnemyState()//处理状态的方法
    {
        switch (enemyState)
        {
            case EnemyState.Patrol://巡逻
            
                OnPatrolState();
                ChangePatrolToOtherState();

                break;
            case EnemyState.Attack://攻击
                OnAttackState();
                ChangeAttackToOtherState();

                break;
            case EnemyState.Rest://休息
                OnRestState();
                ChangeRestToOtherState();
                break;
            case EnemyState.Chase://追击
                OnChaseState();
                ChangeChaseToOtherState();
                break;
            default:
                break;
        }
    }
    private void OnRestState()//处理休息
    {
        RestTime -= Time.deltaTime;//休息时间倒计时
        EnemyAnimator.SetBool("walk", false);
        EnemyAnimator.SetBool("attack", false);//播放动画
        m_navmeshment.speed = 0;//移动速度设置为0
      
    }
    private void OnAttackState()//处理攻击
    {
        
        m_navmeshment.speed = 0;//速度设置为0
        EnemyAnimator.SetBool("attack", true);
        EnemyAnimator.SetBool("walk",false);//播放动画
        
    }
    private void OnChaseState()//处理追击
    {
      
        EnemyAnimator.SetBool("walk", true);
        EnemyAnimator.SetBool("attack", false);//播放动画
        MoveTarget = Player;//设置目标位Player
        m_navmeshment.speed = 0.1f;//设置移动速度
        MoveToTarget(MoveTarget);//开始移动追击
    }

 
    private void OnPatrolState()//处理巡逻
    {
        //移动到目标点,进行位移
        m_navmeshment.speed = 0.1f;
       
        if (canmove)
        {
            MoveToTarget(MoveTarget);
        }
        EnemyAnimator.SetBool("walk", true);
        EnemyAnimator.SetBool("attack", false);
        //播放移动动画
    }
    private void ChangeRestToOtherState()//休息状态到别的状态
    {
        
        if (IsOnSightOfEnemy())//在视野范围内
        {
            MoveTarget = Player;   //设置目标MoveToTarget
            print("在视野内");
            if (IsOnAttackDistance())//在攻击范围内
            {
                print("在攻击范围内");
                enemyState = EnemyState.Attack;//改变状态
            }
            else
            {
                print("不在攻击范围内");
                enemyState = EnemyState.Chase;
            }
        }
        else//不在视野范围内
        //判断倒计时,且目标点还是巡逻点
        {
            //设置目标巡逻点
            if (RestTime <= 0)//倒计时结束
            {
                RestTime = EnemyRestTime;//重置倒计时时间
                canmove = true;//可以移动
                if (index == Points.Count - 1)//循环路点
                {
                    index = 0;
                }
                else
                {
                    index++;
                }
                MoveTarget = Points[index];
                enemyState = EnemyState.Patrol;//改变状态

            }
            else//倒计时未结束，不能移动
            {
                canmove = false;
            }
        }
    }
    private void ChangeAttackToOtherState()
    {
        //时刻监视状态
        if (IsOnSightOfEnemy())
        {
            MoveTarget = Player;   //设置目标MoveToTarget
            print("在视野内");
            if (IsOnAttackDistance())
            {
                print("在攻击范围内");
                enemyState = EnemyState.Attack;
            }
            else
            {
                print("不在攻击范围内");
                enemyState = EnemyState.Chase;
            }
        }
        else
        {
            enemyState = EnemyState.Patrol;//不在视野内，也就是说主角逃走了，设置为巡逻
        }
        //判断血量
        //判断目标
    }//攻击到别的状态
    private void ChangeChaseToOtherState()
    {
        if (IsOnSightOfEnemy())//在视野内
        {
            MoveTarget = Player;   //设置目标MoveToTarget
            print("在视野内");
            if (IsOnAttackDistance())
            {
                print("在攻击范围内");
                enemyState = EnemyState.Attack;
            }
            else
            {
                print("不在攻击范围内");
                enemyState = EnemyState.Chase;
            }
        }
        else
        {
            MoveTarget = Points[index];
            enemyState = EnemyState.Patrol;

        }
    }//追击到别的状态
    private void ChangePatrolToOtherState()
    {
        //监测状态
        if (IsOnSightOfEnemy())
        {
            MoveTarget = Player;   //设置目标MoveToTarget
            print("在视野内");
            if (IsOnAttackDistance())
            {
                print("在攻击范围内");
                enemyState = EnemyState.Attack;
            }
            else
            {
                print("不在攻击范围内");
                enemyState = EnemyState.Chase;
            }
        }
        else
        {
        
            float dis = Vector3.Distance(transform.position, MoveTarget.position);
            if (dis < 0.5f)
            {
                enemyState = EnemyState.Rest;
            }
        }
        //如果不在视野内，目标还是巡逻点
    }//巡逻到别的状态
    private bool IsOnSightOfEnemy()//是否在可视范围内
    {
        bool onsight=false;
        float dis = Vector3.Distance(Player.position, transform.position);
        float angle = Vector3.Angle(transform.forward, Player.position - transform.position);
        if (dis < MaxSightDistance)
        {
            if (angle < 70)
            {
                onsight = true;
            }
        }
        return onsight;
          
      
    }
    private bool IsOnAttackDistance()//判断是否在攻击范围内的方法
    {
        if (IsOnSightOfEnemy())
        {
            float dis = Vector3.Distance(Player.position, transform.position);
            if (dis < CanAttackDistance)
            {
                return true;
            }
        }
        return false;
    }
    private void MoveToTarget(Transform target)//移动的方法
    {
        m_navmeshment.SetDestination(target.transform.position);
    }

}

