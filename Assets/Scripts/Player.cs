using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private float verticalForce = 400f;
    [SerializeField] private float restart = 1f;
    [SerializeField] private ParticleSystem playerParticles;
    Rigidbody2D  playerRB;
    SpriteRenderer playerSR;
    [SerializeField] private Color yellowColor;
    [SerializeField] private Color violetColor;
    [SerializeField] private Color cyanColor;
    [SerializeField] private Color pinkColor;
    private string currentColor;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() //hace lo que escriba una vez que comience el juego
    {
        //Debug.Log("Hola mundo, me ejecuto desde start");
        playerRB = GetComponent<Rigidbody2D>();
        playerSR = GetComponent<SpriteRenderer>();

        ChangeColor();
    }

    // Update is called once per frame
    void Update() //se ejecuta una vez por frame
    {
        if (Input.GetKeyUp(KeyCode.Space)) // en que frame se ejecuta la tecla
        {
            playerRB.linearVelocity = Vector2.zero;
            playerRB.AddForce(new Vector2(0, verticalForce)); //fuerza y direccion, a los ejes x y y 
        }
    }

    /* private void OnCollisionEnter2D(Collision2D collision) //cuando los objetos colisionan
     {
         Debug.Log("Colision con: " + collision.gameObject.name);
         collision.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
     }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag(currentColor))
        {
            gameObject.SetActive(false);
            Instantiate(playerParticles, transform.position, Quaternion.identity);
            Invoke("restartScene", restart);
        }
    }

    void restartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void ChangeColor()
    {
        int randomNumber = Random.Range(0,4);

        switch (randomNumber)
        {
            case 0:
                playerSR.color = yellowColor;
                currentColor = "Yellow";
                break;

            case 1:
                playerSR.color = violetColor;
                currentColor = "Violet";
                break;

            case 2:
                playerSR.color = cyanColor;
                currentColor = "Cyan";
                break;

            case 3:
                playerSR.color = pinkColor;
                currentColor = "Pink";
                break;
        }
    }
}
