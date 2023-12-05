public class LevelSegment
{
	public Option<LevelSegment> right;
	public Option<LevelSegment> left;
	public Option<LevelSegment> up;
	public Option<LevelSegment> down;
	public Direction exitDirection;

	public LevelSegment(Direction exitDirection)
	{
		right = Option<LevelSegment>.None;
		left = Option<LevelSegment>.None;
		up = Option<LevelSegment>.None;
		down = Option<LevelSegment>.None;
		this.exitDirection = exitDirection;
	}
}
