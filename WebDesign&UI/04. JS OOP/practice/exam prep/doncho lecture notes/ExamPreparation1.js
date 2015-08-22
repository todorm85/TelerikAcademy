function solve() {
	if (!Array.prototype.findIndex) {
	  Array.prototype.findIndex = function(predicate) {
	    if (this == null) {
	      throw new TypeError('Array.prototype.findIndex called on null or undefined');
	    }
	    if (typeof predicate !== 'function') {
	      throw new TypeError('predicate must be a function');
	    }
	    var list = Object(this);
	    var length = list.length >>> 0;
	    var thisArg = arguments[1];
	    var value;

	    for (var i = 0; i < length; i++) {
	      value = list[i];
	      if (predicate.call(thisArg, value, i, list)) {
	        return i;
	      }
	    }
	    return -1;
	  };
	}

	function isStringValid(str) {
		if(typeof(str) !== 'string' && str.length < 3 && str.length > 25)
		{
			return true;
		} else {
			return true;
		}
	}
	
	var player = {
			init: function(name){
				return this;
			},

			addPlaylist: function(playlist){

			},

			getPlaylistById: function(id){

			},

			removePlaylist: function(id){

			},

			listPlaylists: function(page, size){

			}
	};

	var playlist = function(){
		var lastId = 0;
		var playlist = {
			init: function(name){
				this.id = lastId += 1;
				this.name = name;
				this.playables = [];
				return this;
			},

			addPlayable: function(playable){
				if(typeof(playable.id) === 'undefined' || !playable.title){
					console.log(playable);
					throw new Error('');
				};
				this.playables.push(playable);
				return this;
			},

			get name(){
				return this._name;
			},
			set name(newName){
				if(!isStringValid(newName, 3, 25)){
					throw new Error();
				}
				this._name = newName;
			},

			getPlayableById: function(id){
				var i,
					len;
				for(i = 0, len = this.playables.length; i < len; i += 1){
					if(this.playables[i].id === id){
						return this.playables[i];
					}
				}
				return null;
			},

			removePlayable: function(id){
				var id = value;
				if(typeof(value) !== 'undefined'){
					throw new Error();
				}
				// ima oshte nedovursheno
				var index = this.playables.findIndex(function(playable){
					return playable.id == id;
				});
				if(index < 0){
					throw new Error();
				}
				this.playables.splice(index, 1);
				return this;
			},
			
			listPlayable: function(page, size){
				if(typeof(page) === 'undefined' || typeof(size) === 'undefined' || page < 0 || size <= 0 || page*size > this.playables.length){
					throw new Error();
				}
				this.playables.sort(function(pl1, pl2){
					if(pl1.title === pl2.title){
						return pl1.id - pl2.title;
					}
					return pl1.title > pl2.title;
				});

				var from = page*size;
				return this.playables.slice(from, size);
			}
		};

		return playlist;
	}();

	var playable =  function(){
		var lastId = 0,
			playable = {
				init: function(title, author, length){
					this.id = lastId += 1;
					this.title = title;
					this.author = author;
					return this;
				},
				get title(){
					return this._title;
				},
				set title(newTitle){
					if(!isStringValid(newTitle, 3, 25)){
						throw new Error('Must be a string between 3 and 25 symbols.');
					}
					this._title = newTitle;
				},
				get author(){
					return this._author;
				},
				set author(newAuthor){
					if(!isStringValid(newAuthor, 3, 25)){
						throw new Error('Must be a string between 3 and 25 symbols.');
					}
					this._author = newAuthor;
				},
				play: function(){
					return this.id + '. ' + this.title +  ' - ' + this.author;
				}
			};
		return playable;
	}();

	var audio = function(parent){
		var audio = Object.create(parent);
		

		audio.init = function(title, author, length){
			parent.init.call(this, title, author);
			this.length = length;
			return this;
		};
		audio.play = function(){
			return parent.play.call(this) + ' - ' + this.length;
		};

		Object.defineProperty(audio, 'length', {
			get: function(){
				return this._length;
			},
			set: function(newLength){
				if(typeof(newLength) !== 'number' || newLength <= 0){
					throw new Error('The length must be a number with minimum 1 length');
				}
				this._length = newLength;
			}
		});
	
		return audio;
	}(playable);

	var video = function(parent){
		var video = Object.create(parent);
		
		video.init = function(title, author, imdbRating){
			parent.init.call(this, title, author);
			this.imdbRating = imdbRating;
			return this;
		};
		video.play = function(){
			return parent.play.call(this) + ' - ' + this.imdbRating;
		};

		Object.defineProperty(video, 'imdbRating', {
			get: function(){
				return this._imdbRating;
			},
			set: function(newImdbRating){
				if(typeof(newImdbRating) !== 'number' || newImdbRating <= 0 || newImdbRating > 5){
					throw new Error('The imdbRating must be a number with between 0 and 5');
				}
				this._imdbRating = newImdbRating;
			}
		});
	
		return video;
	}(playable);

	var module = {
	    getPlayer: function (name){
	        	return Object.create(player).init(name);
	    },

	    getPlaylist: function(name){
	        	return Object.create(playlist).init(name);
	    },

	    getAudio: function(title, author, length){
	        	return Object.create(audio).init(title, author, length);
	    },

	    getVideo: function(title, author, imdbRating){
	        	return Object.create(video).init(title, author, imdbRating);
	    }
	};
	return module;
};

var module = solve();
console.log(module.getAudio('Te sa zeleni', 'Keranov', 3.27).play());

var playlist = module.getPlaylist('rock and roll');
playlist.addPlayable(module.getAudio('te sa zeleni', 'keranov', 3.37));
console.log(playlist.listPlayable(0, 10));