DoublyLinkedList myList = new();
Random rand = new();
for (int i = 0; i < 40; i++)
{
    myList.AddFirst(i + rand.Next(1, 10));
}
myList.PrintAllNodes();
try
{
    myList.AddAtIndex(10, 3);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
myList.PrintAllNodes();
try
{
    myList.RemoveAtIndex(4);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
myList.PrintAllNodes();
try
{
    myList.ReverseList();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
myList.PrintAllNodes();
try
{
    myList.Sort();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
myList.PrintAllNodes();



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
    public int Length;

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
        Length++;
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
        Length++;
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
        Length++;
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
                Length--;
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
            Length--;
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
        Length--;
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
}


/* En doubly linked list har pointers i begge retninger.
Visuelt vil det se noe sånt som dette ut: NODE[ PREV ][ DATA ][ NEXT ]
Hvert element har i minnet pointers til elementer i begge retninger. Både frem og bakover i listen. 
Dette gir doubly linked lists en fordel over singly linked lists siden søking etter elementer etter index kan gjøres mye raskere, <br/>
siden du kan bruke index som et pivot point i hvor du skal lete etter det du trenger.*/

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

    public int Length = 0;

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
        Length++;
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
        Length++;
    }
    /// <summary>
    /// Her legger vi inn en ny node etter en spesifik node. <br/>
    /// Vi definerer en newNode, og setter .Next til node.Next<br/>
    /// og .Prev til noden vi skal settes inn etter. <br/>
    /// Hvis node.Next != null aka node.Next ikke er tail, så setter vi node.Next.Prev aka det som var .Next pointeren til node sin .Prev pointer til newNode. <br/>
    /// til slutt skjekker vi om tail var node, og har da oppdatert alle referanser rundt node og den nye noden vi skal sette inn. <br/>
    /// </summary>
    /// <param name="node">Noden som ny data skal settes inn etter.</param>
    /// <param name="data"></param>
    public void AddAfter(DoublyLinkedNode node, int data)
    {
        if (node == null) return;
        DoublyLinkedNode newNode = new(data);
        newNode.Next = node.Next;
        newNode.Prev = node;
        if (node.Next != null)
        {
            node.Next.Prev = newNode;
        }
        node.Next = newNode;
        if (node == tail)
        {
            tail = newNode;
        }
        Length++;
    }

    /// <summary>
    /// Her prøver vi å sette inn en ny node før en annen node.<br/>
    /// Vi bruker noden i parameteret for å oppdatere alle referansene for å peke korrekt til det nye elementet som settes inn i .Prev<br/>
    /// Vi skjekker også om noden vi setter noe inn i var head, og oppdaterer head deretter. <br/>
    /// 
    /// </summary>
    /// <param name="node"></param>
    /// <param name="data"></param>
    public void AddBefore(DoublyLinkedNode node, int data)
    {
        if (node == null) return;
        DoublyLinkedNode newNode = new(data);
        newNode.Next = node;
        newNode.Prev = node.Prev;
        if (node.Prev != null)
        {
            node.Prev.Next = newNode;
        }
        node.Prev = newNode;
        if (node == head)
        {
            head = newNode;
        }
        Length++;
    }
    /// <summary>
    /// Her prøver vi å sette inn data på en spesifik index i listen.<br/>
    /// Siden vi tracker både head og tail kan vi velge hvilken som er best å starte ved med en enkel bool <br/>
    /// Vi kan da loope gjennom listen fra start til midtpunkt og adde elementet på lokasjon med AddAfter,<br/>
    /// Eller gå baklengs gjennom listen og legge inn før.
    /// </summary>
    /// <param name="Index"></param>
    /// <param name="data"></param>
    /// <exception cref="IndexOutOfRangeException"></exception>
    public void AddAtIndex(int Index, int data)
    {
        if (Index < 0) throw new IndexOutOfRangeException("Index cannot be negative");
        if (Index == 0)
        {
            AddFirst(data);
            return;
        }
        DoublyLinkedNode current = head;
        int currentIndex = 0;
        bool startFromHead = Index <= Length / 2;
        if (!startFromHead)
        {
            current = tail;
            currentIndex = Length - 1;
        }
        while (current != null)
        {
            if ((startFromHead && currentIndex == Index) || (!startFromHead && currentIndex == Index))
            {
                if (startFromHead)
                {
                    AddBefore(current, data);
                }
                else
                {
                    AddBefore(current, data);
                }
                return;
            }
            if (startFromHead)
            {
                current = current.Next;
                currentIndex++;
            }
            else
            {
                current = current.Prev;
                currentIndex--;
            }
        }
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
        Length--;
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
        Length--;
    }
    /// <summary>
    /// Her prøver vi å fjerne data basert på en verdi. Vi vandrer gjennom hele listen og sammenligner data med parameteret. <br/>
    /// </summary>
    /// <param name="data"></param>
    public void RemoveData(int data)
    {
        DoublyLinkedNode current = head;
        while (current != null)
        {
            if (current.Data == data)
            {
                if (current.Prev == null)
                {
                    RemoveHead();
                }
                else if (current.Next == null)
                {
                    RemoveTail();
                }
                else
                {
                    current.Prev.Next = current.Next;
                    current.Next.Prev = current.Prev;
                    Length--;
                }
                return;
            }
            current = current.Next;
        }
    }
    /// <summary>
    /// Her vandrer vi gjennom listen og unlinker når vi treffer index.<br/>
    /// Siden dette er en doubly linked list som har referanser begge veier, kan vi bruke Index som et pivot point som velger hvor vi skal starte å lete<br/>
    /// </summary>
    /// <param name="Index"></param>
    /// <exception cref="IndexOutOfRangeException"></exception>
    public void RemoveAtIndex(int Index)
    {
        if (Index < 0 || Index >= Length) throw new IndexOutOfRangeException("Index is out of range");
        if (Index == 0)
        {
            RemoveHead();
            return;
        };
        if (Index == Length - 1)
        {
            RemoveTail();
            return;
        };
        DoublyLinkedNode current = null;
        int currentIndex = 0;
        bool startFromHead = Index <= Length / 2;
        if (startFromHead)
        {
            current = head;
            while (currentIndex < Index)
            {
                current = current.Next;
                currentIndex++;
            }
        }
        else
        {
            current = tail;
            currentIndex = Length - 1;
            while (currentIndex > Index)
            {
                current = current.Prev;
                currentIndex--;
            }
        }
        if (current.Prev != null)
        {
            current.Prev.Next = current.Next;
        }
        if (current.Next != null)
        {
            current.Next.Prev = current.Prev;
        }
        Length--;
    }

    /// <summary>
    /// Her vandrer vi gjennom listen, og bruker temp som en plaseholder node slik at vi kan reversere prev og next for alle nodes.<br/>
    /// Da har vi reversert listen vår. 
    /// </summary>
    public void ReverseList()
    {
        DoublyLinkedNode temp = null;
        DoublyLinkedNode current = head;
        while (current != null)
        {
            temp = current.Prev;
            current.Prev = current.Next;
            current.Next = temp;
            current = current.Prev;
        }
        if (temp != null)
        {
            head = temp.Prev;
        }
    }
    /// <summary>
    /// Denne funksjonen splitter listen i to på midten. Og returnerer noden hvor splitten skjedde.<br/>
    /// Den gjør dette ved å ha to nodes. En som looper gjennom listen to steg om gangen, og en som looper gjennom et steg om gangen.<br/>
    /// Når "fast" har truffet slutten på listen, returnerer vi "slow". Dermed har vi funnet noden i midten av listen. 
    /// </summary>
    /// <param name="head"></param>
    /// <returns></returns>
    private DoublyLinkedNode Split(DoublyLinkedNode head)
    {
        DoublyLinkedNode slow = head, fast = head, prev = null;
        while (fast != null && fast.Next != null)
        {
            prev = slow;
            slow = slow.Next;
            fast = fast.Next.Next;
        }
        if (prev != null) prev.Next = null;
        return slow;
    }

    /// <summary>
    /// Denne funksjonen tar inn to nodes, og sammenligner dataverdien mellom de. <br/>
    /// Hvis den ene er større enn den andre, flytter den noden bak eller frem, og caller rekrusivt Merge() på neste par nodes.<br/>
    /// </summary>
    /// <param name="first"></param>
    /// <param name="second"></param>
    /// <returns></returns>
    private DoublyLinkedNode Merge(DoublyLinkedNode first, DoublyLinkedNode second)
    {
        if (first == null) return second;
        if (second == null) return first;
        if (first.Data < second.Data)
        {
            first.Next = Merge(first.Next, second);
            first.Next.Prev = first;
            first.Prev = null;
            return first;
        }
        else
        {
            second.Next = Merge(first, second.Next);
            second.Next.Prev = second;
            second.Prev = null;
            return second;
        }
    }
    /// <summary>
    /// Her lager vi en rekrusiv funksjon som først splitter listen vår i to rundt senter fra "noden" vi starter med.<br/>
    /// Før vi sorterer hver halvdel av listen ved å called MergeSort recrusivt fra splitpunktene. Etter vi har merget nedover called vi Merge funksjonen til slutt for å sammenligne hvert punkt i listen.
    /// </summary>
    /// <param name="node"></param>
    /// <returns></returns>
    public DoublyLinkedNode MergeSort(DoublyLinkedNode node)
    {
        if (node == null || node.Next == null) return node;
        DoublyLinkedNode second = Split(node);
        node = MergeSort(node);
        second = MergeSort(second);
        return Merge(node, second);
    }
    /// <summary>
    /// Alternativ Merge sort siden vi kjenner lengden på listen via Length operator.<br/>
    /// Her bruker vi Length for å limite antal iterations av den rekrusive MergeSort algoritmen.<br/>
    /// Dette kan hjelpe hvor du ikke har mye stack dybde.
    /// </summary>
    /// <param name="node"></param>
    /// <param name="length"></param>
    /// <returns></returns>
    public DoublyLinkedNode MergeSortUsingLength(DoublyLinkedNode node, int length)
    {
        if (length <= 1)
        {
            return node;
        }
        DoublyLinkedNode middle = Split(node);
        DoublyLinkedNode secondHalf = middle.Next;
        middle.Next = null;

        DoublyLinkedNode left = MergeSortUsingLength(node, length / 2);
        DoublyLinkedNode right = MergeSortUsingLength(secondHalf, length - length / 2);
        return Merge(left, right);
    }
    /// <summary>
    /// Her starter vi MergeSorten med startpunktet i listen vår, head. <br/>
    /// Til slutt passer vi på at tail fremdeles refererer til siste element i listen.<br/>
    /// Grunnen til at Mergesort er en bedre sort algorithm enn quicksort for Linked Lists er pga Quicksort er avhengig av direkte access til elementene for å skape pivot points.<br/>
    /// Noe som arrays håndterer bedre via direkte Indexing. Linked lists er ikke avhengig av at elementene er indexed i memory i samme område, så dermed er det vanskeligere å få random access til et element. <br/>
    /// Merge sort er ikke avhengig av dette på samme måte, så vi kan vandre gjennom og splitte listen vår nedover.
    /// </summary>
    public void Sort()
    {
        head = MergeSort(head);
        tail = head;
        while (tail != null && tail.Next != null)
        {
            tail = tail.Next;
        }
    }
    /// <summary>
    /// Her går vi gjennom listen fra begge ender for å finne noden som har dataen vi trenger. <br/>
    /// Vi returnerer noden hvis vi finner den.
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public DoublyLinkedNode Search(int data)
    {
        DoublyLinkedNode forward = head;
        DoublyLinkedNode backward = tail;
        while (forward != null && backward != null && forward != backward && forward.Prev != backward)
        {
            if (forward.Data == data)
            {
                return forward;
            }
            if (backward.Data == data)
            {
                return backward;
            }
            forward = forward.Next;
            backward = backward.Prev;
        }
        return null;
    }
    public void PrintAllNodes()
    {
        DoublyLinkedNode current = head;
        while (current != null)
        {
            Console.Write(current.Data + " ");
            current = current.Next;
        }
        Console.WriteLine();
    }
}
