
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
        let html = "<table class = \"table-bordered table-hover sortable\">";
        /*adding the table row and table headers*/
        html +="<tr><th>ID</th><th>ISBN</th><th>Title</th><th>Author</th><th>Genre</th><th>Price</th></tr>"
        json.forEach((book) => {
            html += "<tr class = \"book\"><td>" + book.id + "</td><td>" + book.isbn + "</td><td>" + book.title + "</td><td>"+ book.author + "</td><td>" + book.genre + "</td>" + "<td>" + "$" + book.price + "</td>";
        });
        html += "</table>";
        //target that html element and set it equal to html
        document.getElementById("books").innerHTML = html;

    }).catch(function(error){ //catch any errors
        console.log(error);
    })
}

function getBooksToDelete(){
    const allBooksApiUrl = "https://localhost:5001/api/books";

    //whatever comes back from allbookspaiurl will go back as the response for the then
    fetch(allBooksApiUrl).then(function(response){
        console.log(response);
        //turn response into a json object we can deal with 
        return response.json();
    }).then(function(json){
        /*border and hover are built into bootstrap and make it prettier*/
        let html = "<table class = \"table-bordered table-hover\">";
        /*adding the table row and table headers*/
        html +="<tr><th>ID</th><th>ISBN</th><th>Title</th><th>Author</th><th>Genre</th><th>Price</th><th>Delete</th></tr>"
        //add each book to the table, including a delete button that links to the delete book method
        json.forEach((book) => {
            html += "<tr><td>" + book.id + "</td><td>" + book.isbn + "</td><td>" + book.title + "</td><td>"+ book.author + "</td><td>"+ book.genre + "</td><td>"+ book.price + "</td>" + 
            "<td><button onclick = \"deleteBook("+book.id+")\">Delete</button></td></tr>";
        });
        html += "</table>";
        //target that html element and set it equal to html
        document.getElementById("delete").innerHTML = html;

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
    const bookPrice = document.getElementById("price").value;

    //make call to the backend, pass it the data, and make it do its thing
    fetch(postBookApiUrl, {
        method: "POST",
        headers: {
            "Accept": 'application/json',
            "Content-Type": 'application/json',
        }, //sending our data
        body:JSON.stringify({
            isbn: parseInt(bookIsbn),
            title: bookTitle,
            author: bookAuthor,
            genre: bookGenre,
            price: parseFloat(bookPrice)
        })
    })
    .then((response)=>{
        console.log(response);
        getBooks();
    })
}

deleteBook = function(id){
    console.log(id);
    //it needs to get an id so the controller knows which to delete
    const deleteBookApiUrl = "https://localhost:5001/api/books/" + id;
    //getting the readlines from the website when a user adds a book

    //make call to the backend, pass it the data, and make it run the delete
    fetch(deleteBookApiUrl, {
        method: "DELETE",
        headers: {
            "Accept": 'application/json',
            "Content-Type": 'application/json',
        }
    })
    .then((response)=>{
        console.log(response);
        getBooksToDelete();
    })
}

function search(){
    const allBooksApiUrl = "https://localhost:5001/api/books";
    const search = document.getElementById("search").value.toLowerCase(); //to lower makes it not case sensitive
    //whatever comes back from allbookspaiurl will go back as the response for the then
    fetch(allBooksApiUrl).then(function(response){
        console.log(response);
        //turn response into a json object we can deal with 
        return response.json();
    }).then(function(json){
        /*border and hover are built into bootstrap and make it prettier*/
        let html = "<table class = \"table-bordered table-hover\">";
        /*adding the table row and table headers*/
        html +="<tr><th>ID</th><th>ISBN</th><th>Title</th><th>Author</th><th>Genre</th><th>Price</th></tr>"
        json.forEach((book) => {
            if (book.title.toLowerCase() == search || book.isbn == search)(
                html += "<tr><td>" + book.id + "</td><td>" + book.isbn + "</td><td>" + book.title + "</td><td>"+ book.author + "</td><td>" + book.genre + "</td>" + "<td>" + "$" + book.price + "</td>"
            )
            
        });
        html += "</table>";
        //target that html element and set it equal to html
        document.getElementById("books").innerHTML = html;

    }).catch(function(error){ //catch any errors
        console.log(error);
    })
}

function searchDelete(){
    const allBooksApiUrl = "https://localhost:5001/api/books";
    const search = document.getElementById("search").value.toLowerCase(); //to lower makes it not case sensitive
    //whatever comes back from allbookspaiurl will go back as the response for the then
    fetch(allBooksApiUrl).then(function(response){
        console.log(response);
        //turn response into a json object we can deal with 
        return response.json();
    }).then(function(json){
        /*border and hover are built into bootstrap and make it prettier*/
        let html = "<table class = \"table-bordered table-hover\">";
        /*adding the table row and table headers*/
        html +="<tr><th>ID</th><th>ISBN</th><th>Title</th><th>Author</th><th>Genre</th><th>Price</th><th>Delete</th></tr>"
        //add each book to the table, including a delete button that links to the delete book method
        json.forEach((book) => {
            if (book.title.toLowerCase() == search || book.isbn == search)(
                html += "<tr><td>" + book.id + "</td><td>" + book.isbn + "</td><td>" + book.title + "</td><td>"+ book.author + "</td><td>"+ book.genre + "</td><td>"+ book.price + "</td>" + 
                "<td><button onclick = \"deleteBook("+book.id+")\">Delete</button></td></tr>"
            )
        });
        html += "</table>";
        //target that html element and set it equal to html
        document.getElementById("delete").innerHTML = html;

    }).catch(function(error){ //catch any errors
        console.log(error);
    })
}

function sortColumn(){
    //call to sort method that gets list then sorts then returns
    const allBooksApiUrl = "https://localhost:5001/api/books";
    allBooksApiUrl.sort
}

// function sort() {
//     //sort method 
//         const allBooksApiUrl = "https://localhost:5001/api/books";
//         fetch(allBooksApiUrl).then(function(response){
//             console.log(response);
//             //turn response into a json object we can deal with 
//             return response.json();
//         }).then(function(json){
//             /*border and hover are built into bootstrap and make it prettier*/
//             let html = "<table class = \"table-bordered table-hover\">";
//             /*adding the table row and table headers*/
//             sorted = true;
//             while (sorted) {
//                  sorted = false;
//                  rows = json.rows;
//                 for (i = 1; i < rows.length - 1; i++) {
//                     sortFlag = false;
//                     x = rows[i].getElementsByTagName("TD")[0];
//                     y = rows[i + 1].getElementsByTagName("TD")[0];
//                     if (x.innerHTML.toLowerCase() > y.innerHTML.toLowerCase()) {
//                     sortFlag = true;
//                     break;
//                     }
//                 }
//                 if (sortFlag) {
//                     rows[i].parentNode.insertBefore(rows[i + 1], rows[i]);
//                     sorted = true;
//                }
//             }
//             html +="<tr><th>ID</th><th>ISBN</th><th>Title</th><th>Author</th><th>Genre</th><th>Price</th></tr>"
//             json.forEach((book) => {
//                     html += "<tr><td>" + book.id + "</td><td>" + book.isbn + "</td><td>" + book.title + "</td><td>"+ book.author + "</td><td>" + book.genre + "</td>" + "<td>" + "$" + book.price + "</td>"
//             });
//             html += "</table>";
//             //target that html element and set it equal to html
//             document.getElementById("books").innerHTML = html;
    
//         }).catch(function(error){ //catch any errors
//             console.log(error);
//         })
//   }





