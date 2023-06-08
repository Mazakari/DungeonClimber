mergeInto(LibraryManager.library, {

   GetPlayerIDData: function () {
	  myGameInstance.SendMessage('YandexAPI', 'SetPlayerIDName', player.getName());
	  myGameInstance.SendMessage('YandexAPI', 'SetPlayerIDAvatar', player.getPhoto("medium"));
	},
	
	RateGame: function () {
	 ysdk.feedback.canReview()
        .then(({ value, reason }) => {
            if (value) {
                ysdk.feedback.requestReview()
                    .then(({ feedbackSent }) => {
                        console.log(feedbackSent);
                    })
            } else {
                console.log(reason)
            }
        })
    },
	
	SavePlayerDataToYandex: function (playerData) {
	  var dataString = UTF8ToString(playerData);
	  var myObj = JSON.parse(dataString);
	  player.setData(myObj);
	  console.log(dataString);
	  console.log(myObj);
    },
	
	LoadPlayerDataFromYandex: function () {
	 player.getData().then(_data => {
		 const myJSON = JSON.stringify(_data);
		 myGameInstance.SendMessage('YandexAPI', 'CopyYandexProgress', myJSON);
		 console.log('Loading saved data');
		 console.log(myJSON);
		
		 
	 });
    },
	
	UpdateLeaderboardData : function (value) {
		ysdk.getLeaderboards()
		.then(lb => {
			// Без extraData
			lb.setLeaderboardScore('MaxClearedLevel', value);
			console.log('Max level saved');
			console.log(value);
		});
	},
	
	GetSystemLanguage : function () {
		var lang = ysdk.environment.i18n.lang;
		var bufferSize = lengthBytesUTF8(lang) + 1;
		var buffer = _malloc(bufferSize);
		stringToUTF8(lang, buffer, bufferSize);
		return buffer;
	},
	
	ShowFullscrenAds : function () {
		myGameInstance.SendMessage('YandexAPI', 'PauseGame');
		
		ysdk.adv.showFullscreenAdv({
			callbacks: {
			onClose: function(wasShown) {
				console.log('Interstitial ads shown');
				myGameInstance.SendMessage('YandexAPI', 'UnPauseGame');
			// some action after close
        },
        onError: function(error) {
			console.log('Interstitial ads show failed');
			myGameInstance.SendMessage('YandexAPI', 'UnPauseGame');
          // some action on error
        }
		}
		})
	},
	
	PlayerAuthorized : function () {
		console.log('Plugin PlayerAuthorized');
		console.log(playerAuthorized);
		
		return playerAuthorized
	},
	
  });