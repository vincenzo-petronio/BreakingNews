<script>
	import { onMount } from 'svelte';

	// export let news_count = 10;

	let listOfNews = [];
	let counter = 1;

	onMount(async () => {
		listOfNews = await GetListOfNewsAsync();
	});

	async function OnRefreshButtonClicked() {
		listOfNews = await GetListOfNewsAsync();
		counter++;
	}

	async function GetListOfNewsAsync() {
		const response = await fetch('http://localhost:5002/api/News');
		const data = await response.json();
		console.log(data);
		return data;
	}
</script>

<h4>List of last news</h4>
<ul>
	{#each listOfNews as { title, timestamp }}
		<li>
			{title} [{timestamp}]
		</li>
	{/each}
</ul>

<button class="btn btn-primary" on:click={OnRefreshButtonClicked}>Refresh</button>
<!-- <input bind:value={counter} /> -->
