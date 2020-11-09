function getBooks(){
    const allBooksApiUrl = "https://localhost:5001/api/books";

    //like netflix- when we are thru calculating the top ten movies today, then run this next thing
    //whatever comes back from allbookspaiurl will go back as the response for the then
    fetch(allBooksApiUrl).then(function(response){
        console.log(response);
        //turn response into a json object we can deal with 
        return response.json();
    }).then(function(json){
        /*border and hover are built into bootstrap and make it prettier*/
        let html = "<table class = \"table-bordered table-hover\">";
        /*adding the table row and table headers*/
        html +="<tr><th>ID</th><th>ISBN</th><th>Title</th><th>Author</th><th>Genre</th></tr>"
        json.forEach((book) => {
            html += "<tr><td>" + book.id + "</td><td>" + book.isbn + "</td><td>" + book.title + "</td><td>"+ book.author + "</td><td>" + book.genre + "</td>";
        });
        html += "</table>";
        //target that html element and set it equal to html
        document.getElementById("books").innerHTML = html;

    }).catch(function(error){ //catch any errors
        console.log(error);
    })
}

function postBook(){
    const postBookApiUrl = "https://localhost:5001/api/books";
    //getting the readlines from the website when a user adds a book
    const bookTitle = document.getElementById("title").value;
    const bookAuthor = document.getElementById("author").value;
    const bookIsbn = document.getElementById("isbn").value;
    const bookGenre = document.getElementById("genre").value;

    //make call to the backend, pass it the data, and make it do its thing
    fetch(postBookApiUrl, {
        method: "POST",
        headers: {
            "Accept": 'application/json',
            "Content-Type": 'application/json',
        },
        body:JSON.stringify({
            isbn: bookIsbn,
            title: bookTitle,
            author: bookAuthor,
            genre: bookGenre
        })
    })
    .then((response)=>{
        console.log(response);
    })
}





