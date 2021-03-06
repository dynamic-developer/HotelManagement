# TinySort

TinySort is a small script that sorts HTMLElements. It sorts by text- or attribute value, or by that of one of it's children.
The examples below should help getting you on your way.

If you find a bug, have a feature request or a code improvement you can [file them here](https://github.com/Sjeiti/TinySort/issues). Please [provide code examples](http://jsfiddle.net/) where applicable.</small>

<div class="alert alert-warning" role="alert"><p>TinySort used to be a jQuery plugin but was rewritten to remove the jQuery dependency. It is now smaller *and* faster (and has no dependencies). Functionality is the same but changes have been made to the parameters and options.</p></div>

## usage

The first (and only required) argument is a [NodeList](https://developer.mozilla.org/en/docs/Web/API/NodeList), an array of HTMLElements or a string (which is converted to a NodeList using document.querySelectorAll).

``` javascript
tinysort(NodeList);
```

The other arguments can be an an options object.

``` javascript
tinysort(NodeList,{place:'end'});
```

If the option object only contains a `selector` you can suffice by using the selector string instead of the object.

``` javascript
tinysort(NodeList,'span.surname');
```

For multiple criteria you can just overload.

``` javascript
tinysort(NodeList,'span.surname','span.name',{data:'age'});
```

Default settings can be changed

``` javascript
tinysort.defaults.order = 'desc';
tinysort.defaults.attr = 'title';
```

### options

The options object can have the following settings:


**options.selector** (String)
A CSS selector to select the element to sort to.

**options.order** (String='asc')
The order of the sorting method. Possible values are 'asc', 'desc' and 'rand'.

**options.attr** (String=null)
Order by attribute value (ie title, href, class)

**options.data** (String=null)
Use the data attribute for sorting.

**options.place** (String='org')
Determines the placement of the ordered elements in respect to the unordered elements. Possible values 'start', 'end', 'first', 'last' or 'org'.

**options.useVal** (Boolean=false)
Use element value instead of text.

**options.cases** (Boolean=false)
A case sensitive sort (orders [aB,aa,ab,bb])

**options.natural** (Boolean=false)
Use natural sort order.

**options.forceStrings** (Boolean=false)
If false the string '2' will sort with the value 2, not the string '2'.

**options.ignoreDashes** (Boolean=false)
Ignores dashes when looking for numerals.

**options.sortFunction** (function=null)
Override the default sort function. The parameters are of a type {elementObject}.

**options.useFlex** (Boolean=true)
If one parent and display flex, ordering is done by CSS (instead of DOM)

**options.emptyEnd** (Boolean=true)
Sort empty values to the end instead of the start


## examples

### default sorting

The default sort simply sorts the text of each element

``` javascript
tinysort('ul#xdflt>li');
```

### sort on any node

TinySort works on any nodeType. The following is a div with spans.

``` javascript
tinysort('div#xany>span');
```

### sorted numbers

TinySort also works on numbers.

``` javascript
tinysort('ul#xnum>li');
```

### mixed literal and numeral

In a normal sort the order would be a1,a11,a2 while you'd really want it to be a1,a2,a11. TinySort corrects this:

``` javascript
tinysort('ul#xmix>li');
```

### sorted by attribute value

Sort by attribute value by adding the 'attr' option. This will sort by attribute of, either the selection, or of the sub-selection (if provided). In this case sort is by href on the anchor sub-selection.

``` javascript
tinysort('ul#xval>li',{selector:'a',attr:'href'});
```

Another example: images sorted by attribute title value.

``` javascript
tinysort('div#ximg>img',{attr:'title'});
```

### sorted by sub-selection

You can provide an additional subselection by setting the `selector` option. If no other options are set you can also just pass the selector string instead of the options object.

In this example the list elements are sorted to the text of the second span.

``` javascript
tinysort('ul#xsub>li','span:nth-child(2)');
```

The following example will only sort the non-striked elements.

``` javascript
tinysort('ul#xattr>li','span:not([class=striked])');
```

### return only sorted elements

By default, all the elements are returned, even the ones excluded by your sub-selection. By parsing the additional parameter 'returns=true' only the sorted elements are returned.
You can also adjust the placement of the sorted values by adding the 'place' attribute. In this case the original positions are maintained.

``` javascript
tinysort('ul#xret>li','span:not([class=striked])',{returns:true,place:'org'})
    .forEach(function(elm){
        elm.style.color = 'red';
    })
;
```

### multiple sort criteria

Sometimes multiple sorting criteria are required. For instance: you might want to sort a list of people first by surname then by name.

For multiple sorting rules you can just overload the parameters. So tinysort(selector,options) becomes tsort(selector,options1,options2,options3...). Note that in the next example the second parameter `'span.name'` will be rewritten internally to `{selector:'span.name'}`.

``` javascript
tinysort('ul#xmul>li','span.name',{selector:'span.date',data:'timestamp'});
```

### non-latin characters

A normal array sorts according to [Unicode](http://en.wikipedia.org/wiki/Unicode), which is wrong for most languages. For correct ordering you can use the charorder plugin to parse a rule with the 'charOrder' parameter. This is a string that consist of exceptions, not the entire alfabet. For characters that should sort equally use brackets. For characters that consist of multiple characters use curly braces. For example:

*   **c????** sorts c ?? and ?? in that order

*   **??????** in absence of a latin character ?? ?? and ?? are sorted after z

*   **??[??????]** ?? ?? and ?? are sorted equally to ??

*   **d{d??}** d?? is sorted as one character after d

*   **??[{Aa}]** Aa is sorted as one character, equal to ??, after z

Here some real examples:

``` javascript
tinysort('ul#greek>li',{charOrder:'??[??]????????[??]????[??]????[??????]????????????[??]??????????[??????]????????[??]'});
```

``` javascript
tinysort('ul#danish>li',{charOrder:'??????[{Aa}]'});
```

``` javascript
tinysort('ul#serb>li',{charOrder:'c????d{d??}??l{lj}n{nj}s??z??'});
```

Here are some example languages:

<div class="table-responsive">
<table class="props">
    <thead><tr>
        <th>Language</th>
        <th>charOrder</th>
    </tr></thead>
    <tfoot><tr>
        <td colspan="2">since only one of these is my native language please feel free to contact me if you think corrections are in order</td>
    </tr></tfoot>
    <tbody>
        <tr><td>Cyrilic</td><td>????????????????????????????????????????????????????????????</td></tr>
        <tr><td>Czech</td><td>a[??]c??d[??]e[????]h{ch}i[??]n[??]o[??]r??s??t[??]u[????]y[??]z??</td></tr>
        <tr><td>Danish and Norwegian</td><td>??????[{Aa}]</td></tr>
        <tr><td>Dutch</td><td>a[????????]c[??]e[????????]i[????????]o[????????]u[????????]</td></tr>
        <tr><td>French</td><td>a[????]c[??]e[????????]i[????]o[????]u[????]</td></tr>
        <tr><td>German</td><td>a[??]o[??]s{ss}u[??]</td></tr>
        <tr><td>Greek</td><td>??[??]????????[??]????[??]????[??????]????????????[??]??????????[??????]????????[??]</td></tr>
        <tr><td>Icelandic</td><td>a[??]d??e[??]i[??]o[??]u[??]y[??]z??????</td></tr>
        <tr><td>Polish</td><td>a??bc??e??l??n??o??s??u??z????</td></tr>
        <tr><td>Serbo-Croatian</td><td>c????d{d??}??l{lj}n{nj}s??z??</td></tr>
        <tr><td>Spanish</td><td>a[??]c{ch}e[??]i[??]l{ll}n??o[??]u[??]y[??]</td></tr>
        <tr><td>Swedish</td><td>??????</td></tr>
    </tbody>
</table>
</div>

### natural sorting

Machines read differently than you do. Natural sorting makes your machine more like you by enabling it to differentiate between numeric values within a string. 

``` javascript
tinysort('ul#xnat>li',{natural:true});
```

### sort by value

The value property is primarily used to get the values of form elements, but list-elements also have the value property. By setting the useVal option you can also sort by this form element value.

``` javascript
tinysort('ul#xinp>li',{selector:'input',useVal:true});
```

### sort by data

Sort by data attribute by setting the `data` option.

``` javascript
tinysort('ul#xdta>li',{selector:'a',data:'foo'});
```

### sorted descending

Sort in ascending or descending order  by setting the `order` option to `asc` or `desc`.

``` javascript
tinysort('ul#xdesc>li',{order:'desc'});
```

### randomize

TinySort can also order randomly (or is that a contradiction).

``` javascript
tinysort('ul#xrnd>li',{order:'rand'});
```

### parsing a custom sort function

Custom sort functions are similar to those you use with regular Javascript arrays with the exception that the parameters a and b are objects of a similar type {elementObject}, an object with the following properties:

 * elm {HTMLElement}: The element
 * pos {number}: original position
 * posn {number}: original position on the partial list

``` javascript
tinysort('ul#xcst>li',{sortFunction:function(a,b){
var lenA = a.elm.textContent.length
    ,lenB = b.elm.textContent.length;
return lenA===lenB?0:(lenA>lenB?1:-1);
}});
```

### sorting tables

With a little extra code you can create a sortable table:

``` javascript
var table = document.getElementById('xtable')
    ,tableHead = table.querySelector('thead')
    ,tableHeaders = tableHead.querySelectorAll('th')
    ,tableBody = table.querySelector('tbody')
;
tableHead.addEventListener('click',function(e){
    var tableHeader = e.target
        ,textContent = tableHeader.textContent
        ,tableHeaderIndex,isAscending,order
    ;
    if (textContent!=='add row') {
        while (tableHeader.nodeName!=='TH') {
			tableHeader = tableHeader.parentNode;
		}
        tableHeaderIndex = Array.prototype.indexOf.call(tableHeaders,tableHeader);
        isAscending = tableHeader.getAttribute('data-order')==='asc';
        order = isAscending?'desc':'asc';
        tableHeader.setAttribute('data-order',order);
        tinysort(
            tableBody.querySelectorAll('tr')
            ,{
                selector:'td:nth-child('+(tableHeaderIndex+1)+')'
                ,order: order
            }
        );
    }
});
```

<div class="table-responsive">
<table class="props xmpl" id="xtable">
    <thead>
        <tr>
            <th><a>word</a></th>
            <th><a>int</a></th>
            <th><a>float</a></th>
            <th><a>mixed</a></th>
            <th><a>add row</a></th>
        </tr>
    </thead>
    <tbody></tbody>
</table>
</div>

### animated sorting

Tinysort has no built in animating features but it can quite easily be accomplished through regular js/jQuery.

<style type="text/css">
	ul#xanim {
	    position: relative;
	    display: block;
	}
	ul#xanim li {
		transition: top 500ms;
		-webkit-transition: top 500ms;
	}
</style>

``` javascript
var ul = document.getElementById('xanim')
	,lis = ul.querySelectorAll('li')
	,liHeight = lis[0].offsetHeight
;
ul.style.height = ul.offsetHeight+'px';
for (var i= 0,l=lis.length;i<l;i++) {
	var li = lis[i];
	li.style.position = 'absolute';
	li.style.top = i*liHeight+'px';
}
tinysort('ul#xanim>li').forEach(function(elm,i){
    setTimeout((function(elm,i){
        elm.style.top = i*liHeight+'px';
    }).bind(null,elm,i),40);
});
```
