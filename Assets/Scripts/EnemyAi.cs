using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    public GameObject target;
    class Path:object
    {
    public int g;         // Steps from A to this
    public int h;         // Steps from this to B
    public Path parent;   // Parent node in the path
    public int x;         // x coordinate
    public int y;         // y coordinate
    public Path (int _g, int _h, Path _parent, int _x, int _y)
    {
        g = _g;
        h = _h;
        parent = _parent;
        x = _x;
        y = _y;
    }
    public int f // Total score for this
    {
        get 
        {
            return g+h; 
        }
    }
    }
    // Start is called before the first frame update
    void Start()
    {
        target = GetComponent<BaseEnemy>().getTargetPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*public void HappyPath() {
        Path destinationSquare = new Path (/* target position /);
        evaluationList.Add(new Path(/* starting position /));
        Path currentSquare = null;
        while(evaluationList.Count > 0)
        {
            currentSquare = itemWithLowestFScore(evaluationList);
            closedPathList.Add(currentSquare);
            evaluationList.Remove(currentSquare);
            // The target has been located
            if (doesPathListContain (closedPathList, destinationSquare))
            {
                return buildPath (currentSquare);
                break;
            }
            List adjacentSquares = GetAdjacentSquares(currentSquare);
            foreach (Path p in adjacentSquares) {
                if(doesPathListContain(closedPathList,p))
                    continue; // skip this one, we already know about it
            if (!doesPathListContain(evaluationList,p)) {
                openPathList.Add (p);
            }
            else if (p.H + currentSquare.G + 1 < p.F)
                p.parent = currentSquare;
            }
        }
    }
// Simply used because at the end of our loop we have a path with parents in the reverse order. 
//This reverses the list so it's from Enemy to Player
private List<Path> buildPath(Path p) {
    List<Path> bestPath = new List<Path> ();
    Path currentLoc = p;
    bestPath.Insert (0,currentLoc);
    while (currentLoc.parent != null) {
        currentLoc = currentLoc.parent;
        bestPath.Insert (0, currentLoc);
    }
    return bestPath;
}

    private List<Path> GetAdjacentSquares(Path p) {
        List<Path> ret = new List<Path> ();
        int _x = p.x;
        int _y = p.y;
        for (int x = -1; x <= 1; x++) {
            for (int y = -1; y <= 1; y++) {
                int __x = _x + x; // easier than writing (_x + x) 5 times
                int __y = _y + y; // easier than writing (_y + y) 5 times
                // skip self and diagonal squares
                if ((x == 0 && y == 0) || (x != 0 && y != 0))
                    continue;
                else if (__x < GameManager.instance.numCols && __y < GameManager.instance.numRows && __x >= 0 && __y >= 0 &&
                    !CheckForCollision(new Vector2(_x,_y),new Vector2(__x,__y)))
                        ret.Add(new Path(p.g+1, BlocksToTarget(new Vector2(__x,__y), target.transform.position), p, __x, __y));
            }
        }
    return ret;
    }
    
    private bool CheckForCollision(Vector2 start, Vector2 end) {
        this.GetComponent<BoxCollider2D>().enabled = false;
        RaycastHit2D hit = Physics2D.Linecast (start, end);
        this.GetComponent<BoxCollider2D>().enabled = true;
        // trying to walk into a wall, change direction
        if (hit.transform != null && !hit.collider.tag.Equals("Player"))
        {
            
            return true;
        }
        return false;
    }
    private int BlocksToTarget(Vector2 enemyPos, Vector2 targetPos){
        return (int)Vector2.Distance(enemyPos, targetPos);
    }*/
}