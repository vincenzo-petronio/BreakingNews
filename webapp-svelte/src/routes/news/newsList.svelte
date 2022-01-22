<script>
	let listOfNews = [
		{ title: 'aaa', timestamp: '2022-01-01' },
		{ title: 'bbb', timestamp: '2022-01-02' },
		{ title: 'ccc', timestamp: '2022-01-03' },
		{ title: 'ddd', timestamp: '2022-01-04' }
	];

    let counter = 1;

	function OnRefreshButtonClicked() {
        // listOfNews.push({title: 'refresh ' + counter, timestamp: new Date()});
        // listOfNews.push({title: 'eee', timestamp: '2022-01-05'});
        counter++;
    }
</script>

<h2>List of news</h2>
<ul>
	{#each listOfNews as { title, timestamp }}
		<li>
			{title} [{timestamp}]
		</li>
	{/each}
</ul>

<button on:click={OnRefreshButtonClicked}>Refresh</button>
<input bind:value="{counter}">
