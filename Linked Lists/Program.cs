
LinkedList myList = new();
Random rand = new();

myList.AddFirst(1);
myList.AddFirst(2);
myList.AddLast(3);
myList.RemoveData(3);
myList.RemoveHead();
myList.AddFirst(4);
myList.AddLast(6);

try
{
    myList.RemoveAtIndex(1);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}


for (int i = 0; i <= 12; i++)
{
    myList.AddFirst(i + rand.Next(1, 10));
}

try
{
    myList.AddAtIndex(10, 2);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

myList.PrintAllNodes();

try
{
    Console.WriteLine(myList.GetElementAtIndex(12));
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
Console.WriteLine(myList.GetLength());



/* Hvert element i en linked list blir ofte kalt for en "node". <br/>

En linked list er en liste med memory som også har en referanse til neste element i listen. <br/>

Visuellt vil det se noe som dette: NODE:[ DATA ][ NEXT ], Hver node sitt minne kan deles opp i data, og referansepointers til andre elementer i listen.<br/>

I mer avanserte lister kan de også ha en referanse til den forrige i listen. */
public class Node
{
    public int Data { get; set; }
    public Node Next { get; set; }
    public Node(int data)
    {
        this.Data = data;
        this.Next = null;
    }
}

/* Selve listen er å sette opp et system som håndterer hva som er "head" eller først i listen, og hva som er current i listen. Rekkefølgen kommer naturlig av pointers.  */

public class LinkedList
{
    private Node head;

    /// <summary>
    /// I AddFirst setter vi et nytt datapoint som først i listen. 
    /// 
    /// Vi gjør dette ved å først definere en ny node, med data. Så setter vi newNode til Head. Vi setter først newNode.Next til head av listen vår. <br/>
    /// Då vil newNode.Next peke til det som var starten på listen. <br/>
    /// Så setter vi head til newNode, det gjør at starten på listen nå er newNode, men newNode.Next peker på det som tidligere var newNode. Dette gjør at "chainen" er beholdt intakt, med newNode i starten. <br/>
    /// 
    /// </summary>
    /// <param name="data">I dette tilfellet bruker vi tall som data</param>
    public void AddFirst(int data)
    {
        Node newNode = new Node(data);
        newNode.Next = head;
        head = newNode;
    }
    /// <summary>
    /// Denne methoden vandrer gjennom listen, til den kommer til slutt, før den inserter vår newNode til enden av listen, og oppdaterer listen der etter.<br/>
    /// <br/>
    /// Vi begynner med å initialisere et nytt Node element med dataen vi vil lagre. <br/>
    /// 
    /// Så skjekker vi om listen har et element i head. Hvis listen ikke har en head setter vi head som newNode og vi er ferdig. <br/>
    /// 
    /// Hvis den har et head, lager vi en ny node referanse som heter current, og setter head til current. <br/>
    /// 
    /// Så ser vi om current.Next finnes. Så lenge current.Next eksisterer, vandrer vi gjennom listen ved å sette current = current.Next; <br/>
    /// 
    /// Når vi har funnet en plass hvor current.Next er null, setter vi current.Next til newNode. Da har vi plasert vår node på enden av listen <br/>
    /// </summary>
    /// <param name="data"></param>
    public void AddLast(int data)
    {
        Node newNode = new Node(data);
        if (head == null)
        {
            head = newNode;
            return;
        }
        Node current = head;
        while (current.Next != null)
        {
            current = current.Next;
        }
        current.Next = newNode;
    }

    /// <summary>
    /// Her vandrer vi gjennom listen vår, og inserter dataen vår ved hjelp av en counter.<br/>
    /// Vi endrer på referansen på listelemeneted i positionen før hvor vi vil sette det inn, for å referere til det nye elementet.<br/>
    /// hvis indexen vi vil putte det inn i er 0, kjører vi AddFirst isteden.
    /// </summary>
    /// <param name="data"></param>
    /// <param name="Index"></param>
    /// <exception cref="IndexOutOfRangeException"></exception>
    public void AddAtIndex(int data, int Index)
    {
        if (Index == 0)
        {
            AddFirst(data);
        }
        Node newNode = new(data);
        Node current = head;
        for (int i = 0; i < Index - 1; i++)
        {
            if (current == null)
            {
                throw new IndexOutOfRangeException("Index is out of bounds");
            }
            current = current.Next;
        }
        newNode.Next = current.Next;
        current.Next = newNode;
    }

    /// <summary>
    /// Her vandrer vi gjennom listen og printer ut hvert element while current ikke er null.
    /// </summary>
    public void PrintAllNodes()
    {
        Node current = head;
        while (current != null)
        {
            Console.WriteLine(current.Data);
            current = current.Next;
        }
    }


    /// <summary>
    /// Her prøver vi å slette et element fra listen vår. <br/>
    /// Vi kan "slette" en node ved å fjerne alle referanser til noden. <br/>
    /// Da blir noden en kanditat for garbage-collection. <br/>
    /// Når vi sletter elementet er det mer rett å si at vi fjerner referansene til elementet fra listen vår. <br/>
    /// Vi gjør dette ved å se lage både en current og en previous node referanse i starten <br/>
    /// Vi trenger både current og previous for å endre på referansene, dvs pointers, slik at elementet blir fjernet. <br/>
    /// Vi vandrer gjennom listen så lenge current ikke er null. Hvis vi finner et element hvor dataen er lik det vi vil fjerne <br/>
    /// tar vi å endrer referansene i listen vår. b.la setter vi previous.Next til current.Next. slik at linken fremdeles er hel. <br/>
    /// Viss vi når enden og ingenting er endret returnerer vi false, i.e. slettingen funkerte ikke. 
    ///
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public bool RemoveData(int data)
    {
        Node current = head;
        Node previous = null;
        while (current != null)
        {
            if (current.Data == data)
            {
                if (previous == null)
                {
                    head = current.Next;
                }
                else
                {
                    previous.Next = current.Next;
                }
                return true;
            }
            previous = current;
            current = current.Next;
        }
        return false;
    }

    /// <summary>
    /// Her fjerner vi, dvs un-linker head fra chainen av elementer.
    /// </summary>
    public void RemoveHead()
    {
        if (head != null)
        {
            head = head.Next;
        }
    }
    /// <summary>
    /// Her fjerner vi data basert på en Index. <br/>
    /// Vi vandrer i listen til vi treffer punktet vi vil fjerne, og "un-linker" det fra de andre referansepunktene i listen. <br/>
    /// </summary>
    /// <param name="Index"></param>
    /// <exception cref="IndexOutOfRangeException"></exception>
    public void RemoveAtIndex(int Index)
    {
        if (head == null || Index < 0)
        {
            throw new IndexOutOfRangeException("Index is out of bounds");
        }
        Node current = head;
        Node previous = null;
        for (int i = 0; i < Index; i++)
        {
            if (current.Next == null)
            {
                throw new IndexOutOfRangeException("Index is out of bounds");
            }
            previous = current;
            current = current.Next;
        }
        if (previous == null)
        {
            head = head.Next;
        }
        else
        {
            previous.Next = current.Next;
        }
    }

    /// <summary>
    /// Linked lists støtter ikke å søke etter en index slik i.e. arrays gjør. I et arrays er start og slutt og rekkefølgen hellig. I en linked list spiller ikke rekkefølgen noe rolle så lenge chainen er hel. <br/>
    /// Det vil si hvert element kan være hvor som helst så lenge pointerene pointer til "neste" og eller "forrige" i listen. <br/>
    /// De er ikke naturlig indexed med en spesifikk index. <br/>
    /// Vi kan sette det opp selv med en metode: <br/>
    /// Vi kan vandre gjennom listen til vi finner dataen i valgt index ved å incremente en counter for hvert steg <br/>
    /// Da må vi passe på å håndtere tilfeller hvor vi er out of range, med en IndexOutOfRangeException<br/>
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    /// <exception cref="IndexOutOfRangeException"></exception>
    public int GetElementAtIndex(int index)
    {
        Node current = head;
        int count = 0;
        while (current != null)
        {
            if (count == index)
            {
                return current.Data;
            }
            count++;
            current = current.Next;
        }
        throw new IndexOutOfRangeException("Index is out of range");
    }
    /// <summary>
    /// Vi kan finne lengden på listen ved å vandre gjennom listen og incremente en counter.
    /// </summary>
    /// <returns></returns>
    public int GetLength()
    {
        if (head == null) return 0;
        Node current = head;
        int count = 1;
        while (current != null)
        {
            count++;
            current = current.Next;
        }
        return count;
    }
}


/* En doubly linked list har pointers i begge retninger.
Visuelt vil det se noe sånt som dette ut: NODE[ PREV ][ DATA ][ NEXT ]
Hvert element har i minnet pointers til elementer i begge retninger. Både frem og bakover i listen. */

public class DoublyLinkedNode
{
    public int Data { get; set; }
    public DoublyLinkedNode Next { get; set; }
    public DoublyLinkedNode Prev { get; set; }
    public DoublyLinkedNode(int Data)
    {
        this.Data = Data;
        this.Next = null;
        this.Prev = null;
    }
}

public class DoublyLinkedList
{
    private DoublyLinkedNode head;
    private DoublyLinkedNode tail;

    /// <summary>
    /// Her legger vi inn data som det første elementet i listen vår.<br/>
    /// Hvis det ikke er det første elementet i listen, er det viktig at vi oppdaterer .Next til det som var head <br/>
    /// og .Prev i head til det nye elementet. Da har vi oppfylt pointer kravene til en doubly linked list. <br/>
    /// </summary>
    /// <param name="data"></param>
    public void AddFirst(int data)
    {
        DoublyLinkedNode newNode = new(data);
        newNode.Next = head;
        if (head != null) head.Prev = newNode;
        head = newNode;
        tail ??= head;
    }
    /// <summary>
    /// Her legger vi inn data som "tail" i listen, aka siste element. <br/>
    /// Vi passer på at tail.Next refererer til newNode, og at newNode.Prev refererer til tail.<br/>
    /// Vi setter så tail til newNode, og har så oppfulgt kravene til en doubly linked list.
    /// </summary>
    /// <param name="data"></param>
    public void AddLast(int data)
    {
        if (head == null)
        {
            AddFirst(data);
            return;
        }
        DoublyLinkedNode newNode = new(data);
        tail.Next = newNode;
        newNode.Prev = tail;
        tail = newNode;
    }
    /// <summary>
    /// Her fjerner vi Head fra listen vår ved å fjerne alle referanser til elementet. <br/>
    /// Dette åpner head for garbage collection siden ingenting refererer til det lengre.
    /// </summary>
    public void RemoveHead()
    {
        if (head == null) return;
        if (head.Next == null)
        {
            head = null;
            tail = null;
        }
        else
        {
            head = head.Next;
            head.Prev = null;
        }
    }
    /// <summary>
    /// Her fjerner vi Tail fra listen vår ved å fjerne alle referanser til elementet.<br/>
    /// Dette åpner tail opp for garbage collection siden ingenting refererer til tail lengre.
    /// </summary>
    public void RemoveTail()
    {
        if (tail == null) return;
        if (tail.Prev == null)
        {
            head = null;
            tail = null;
        }
        else
        {
            tail = tail.Prev;
            tail.Next = null;
        }
    }
    public void PrintAllNodes()
    {
        DoublyLinkedNode current = head;
        while (current != null)
        {
            Console.WriteLine(current.Data);
            current = current.Next;
        }
    }
}
