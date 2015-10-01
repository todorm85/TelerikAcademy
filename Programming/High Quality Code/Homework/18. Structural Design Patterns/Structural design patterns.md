# Структурни шаблони за дизайн

## Фасада

### Определение
Обект, който улеснява употребата на друг код или библиотека. Фасадата най-често е опростен интерфейс към външна библиотека. Целта й е да се направи нов интерфейс, който е лесен за употреба и по-разбираем от външни библиотеки или програми, които реферират дадена библиотека.
Много често фасадата намалява зависимостта на външните библиотеки, защото се явява единствена точка на достъп до вътрешния код. Външният код знае само за нея и нейните методи и по никакъв начин за вътрешната сложна стурктура и йерархия от класове. Това от друга страна води и до възможността от по-лесно мокване на фасадата при юнит тестване.

### Структура
Фасдата най-често е клас, чийто публични методи са интерфейсът за достъп до някаква библиотека или апи. Цялата логика по достъпът до външната библиотека е скрита в този клас.

### Подобни патърни
Адаптер патърна наподобява фасада защото също като нея предлага по-подходящ интерфейс за достъп до някаква външна библиотека. Това, което се различава е, че причината и целта на адаптера е не да се улесни достъп до външна библиотека, а да се интегрира по-безпроблемно тя в даден код, като се подмени нейният интерфейс с интерфейса, който се използва в дадения код. Фасадата не нагажда външен интерфейс към вътрешен, а създава изцяло нов, който е много по-лесен за употреба и би свършил работа, не само за конкретен код, а и за всички останали, които използват същата библиотека.



## Композит

### Определение
Похват, който позволява да се обединят различни по тип обекти в една обща дървовидна структура. По този начин се създава възможност да се използват по еднакъв начин групи или отделни представители на тези групи от обект.

### Структура
Композит патърна задължително включва създаването на един общ интерфейс или базов клас, който всички типове трябва да наследяват или имплементират съответно. В този общ интерфейс/клас се задава общата функционалност, която всеки един член на дървовидната структура е нужно да има. Следващата стъпка е да се имплементира тази функционалност в конкретните типове, които трябва да са част от дървото. На типовете, които е необходимо да са 'съставни' се създава пропърти колекция, съдържаща типове, имплементиращи общия интерфейс/клас. По този начин самите съставни типове могат да съдържат други съставни типове, които да съдържат други съставни и т.н. Типовете, които не е нужно да са съставни просто имплементират общата функционалност за дървото и могат да се добавят към съставни типове.



## Флайуейт

### Определение
Похват, при който се преизползва един и същ обект в паметта да представлява различни логически обекти в програмата чрез подаване на параметри или модифициране на пропъртита за конкретния контекст на употреба. Подадените параметри определят конкретното поведение или състояние на обекта в даден контекст. По този начин реално се симулират различни голям брой обекти като се използва един единствен обект от паметта. Съхраняват се конфигурациите (външното състояние на обектите) вместо целите обекти (вътрешното и външното им състояние). Например нека имаме множество обекти с някакво състояние, което заема голямо количество памет, и те се различават един от друг по някаква минимална част от това състояние. Общото състояние, по което всички обекти си приличат може да се приеме за споделено (вътрешно) и да се създаде един обект в паметта, който да се извиква с определени параметри, които го модифицират до конкретното състояние за необходим контекст. Реално подаваните параметри при извикване на инстанцията са външното състояние и определят контекста на употреба.

### Структура
Обикновено се създава клас фабрика, която се грижи за създаването и съхранението на флайуейтите. Тя връща конкретният фалйуейт обект (който може и да е абстрактен тип или интерфейс). Винаги се връща една и съща инстанция на флайуейта, като на нея се подават параметри, които да модифицират поведението и/или състоянието й.

### Разяснение относно примера
Прочетете summary на Program.Main() в предоставения пример за повече разяснения относно патърна.