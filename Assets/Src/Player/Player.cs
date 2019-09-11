using UnityEngine;

public class Player : MonoBehaviour {

    public float speed = 1f;
	public float initialVelocity = 2f;
	public float decay = 0.1f;

	private int score = 0;
	private float velocity = 0;
	private int moveCount = 0;
	private CharacterController cc;

    enum State {
        Idle,
        Moving,
		Won
    }

    private State currentState = State.Idle;

	void Start() {
		cc = this.GetComponent<CharacterController>();
	}

	void Update() {
        Vector3 direction = Physics.gravity;
		direction += this.transform.forward * velocity;

		cc.Move(direction * Time.deltaTime);

		switch (this.currentState) {
			case State.Idle:
				this.Idle();
				break;
			case State.Moving:
				this.Moving();
				break;
			case State.Won:
				this.Won();
				break;
		}
	}

	void Idle () {
		if (Input.GetKey(KeyCode.LeftArrow)) {
			this.transform.rotation *= Quaternion.Euler(0, -this.speed * Time.deltaTime, 0);
		}

		if (Input.GetKey(KeyCode.RightArrow)) {
			this.transform.rotation *= Quaternion.Euler(0, this.speed * Time.deltaTime, 0);
		}

		if (Input.GetKey(KeyCode.Space)) {
			this.currentState = State.Moving;
			this.velocity = this.initialVelocity;
			this.moveCount++;

            /////////////////////////////////////////////////////////
            Toolbox.GetInstance().GetManager<GameManager>().AddMoveCount();
            /////////////////////////////////////////////////////////
        }
    }

	void Moving () {
		if (velocity > 0f) {
			this.velocity -= this.decay;
			this.velocity = Mathf.Clamp(this.velocity, 0, float.MaxValue);
		} else {
			this.velocity = 0;
			this.currentState = State.Idle;
		}
	}

	void Won () {
		this.velocity = 0;
        /////////////////////////////////////////////////////////
        Toolbox.GetInstance().GetManager<GameManager>().AddSceneTime();
        Toolbox.GetInstance().GetManager<GameManager>().NextScene();
        /////////////////////////////////////////////////////////
    }

    void OnControllerColliderHit(ControllerColliderHit hit) {
		if (this.currentState != State.Won) {
			PlayerInteractable pi = hit.gameObject.GetComponent<PlayerInteractable>();
			if (pi) {
				pi.OnHit(hit, this);

                /////////////////////////////////////////////////////////
                if (pi.GetComponent<Killing>())
                {
                    Toolbox.GetInstance().GetManager<GameManager>().AddSceneTime();
                    Toolbox.GetInstance().GetManager<GameManager>().AddDiedCount();
                    Toolbox.GetInstance().GetManager<GameManager>().Respawn();
                }
                /////////////////////////////////////////////////////////
            }
        }
	}

    public float GetVelocity () {
		return this.velocity;
	}

	public void SetVelocity (float vel) {
		this.velocity = vel;
	}

	public void HasWon () {
		this.currentState = State.Won;
	}

	public int AccumulateScore (int scoreAdd) {
		this.score += scoreAdd;

        /////////////////////////////////////////////////////////
        Toolbox.GetInstance().GetManager<GameManager>().AddScore(this.score);
        /////////////////////////////////////////////////////////

        return this.score;
	}
}
