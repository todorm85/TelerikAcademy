function* idFactory() {
    var id = 0;
    while(true) {
        yield(id += 1);
    }
}

var idGen1 = idFactory();

for (var i = 0; i < 15; i+=1) {
    console.log(idGen1.next());
}

